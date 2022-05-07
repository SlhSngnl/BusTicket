using BusTicketOBilet.Models;
using BusTicketOBilet.Services.Interfaces;
using BusTicketOBiletDomain;
using BusTicketOBiletDomain.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;

namespace BusTicketOBilet.Services.Classes
{
    public class TicketService : ITicketService
    {
        private readonly OBiletAppSettings _appSettings;
        private readonly OBiletDbContext _context;

        public TicketService(OBiletAppSettings appSettings, OBiletDbContext context)
        {
            _appSettings = appSettings;
            _context = context;

        }
        public JourneyVM GetJourney(IndexVM model)
        {
            JourneyRequestModel requestModel = new()
            {
                DeviceSession = new DeviceSession()
                {
                    DeviceID = _context.Sessions.Where(x => x.ClientIP == model.IPAddress).Select(x => x.DeviceID).FirstOrDefault(),
                    SessionID = _context.Sessions.Where(x => x.ClientIP == model.IPAddress).Select(x => x.SessionID).FirstOrDefault()
                },
                Data = new JourneyRequestData()
                {
                    DepartureDate = model.DepartureDate.ToString("yyyy-MM-dd"),
                    DestinationID = model.DestinationID,
                    OriginID = model.OriginID
                }
            };

            var journeyResponse = PostRequest<JourneyResponseModel>(requestModel, _appSettings.GetBusJourney);


            if (journeyResponse.ResponseStatus != Models.ResponseStatus.Success)
                return new JourneyVM { ErrorMessage = journeyResponse.Message, UserMessage = journeyResponse.UserMessage };

            if (journeyResponse.Data.Length == 0)
                return new JourneyVM { UserMessage = "Seçtiğiniz tarihler arasında sefer bulunamadı!" };

            string destinationName = _context.Locations.Where(x => x.ID == model.DestinationID).Select(x => x.Name).First();
            string originName = _context.Locations.Where(x => x.ID == model.OriginID).Select(x => x.Name).First();


            return new JourneyVM
            {
                BusJourneyResponse = journeyResponse.Data,
                DeperatureDate = model.DepartureDate.ToString("dd MMMM dddd"),
                DestinationName = destinationName,
                OriginName = originName
            };





        }

        public IndexVM GetLocation(SessionModel model)
        {
            GetSession(model);


            LocationRequestModel requestModel = new LocationRequestModel()
            {
                DeviceSession = new DeviceSession()
                {
                    DeviceID = _context.Sessions.Where(x => x.ClientIP == model.IpAddress).Select(x => x.DeviceID).FirstOrDefault(),
                    SessionID = _context.Sessions.Where(x => x.ClientIP == model.IpAddress).Select(x => x.SessionID).FirstOrDefault()
                },
                Data = "",
            };

            var locationResponse = PostRequest<LocationResponseModel>(requestModel, _appSettings.GetBusLocation);


            if (locationResponse.ResponseStatus != Models.ResponseStatus.Success)
                return new IndexVM { ErrorMessage = locationResponse.Message, UserMessage = locationResponse.UserMessage };


            foreach (var item in locationResponse.Data)
            {
                var locations = _context.Locations.Where(x => x.ID == item.ID).FirstOrDefault();

                if (locations == null)
                {
                    _context.Locations.Add(new Location
                    {
                        ID = item.ID,
                        ParentID = item.ParentID,
                        Keywords = item.Keywords,
                        Name = item.Name,
                        Rank = item.Rank,
                        ReferenceCode = item.RefCode,
                        TZCode = item.TimeZoneCode,
                        Type = item.Type,
                        WeatherCode = item.WeatherCode,
                        Zoom = item.Zoom,
                        Latitude = item.GeoLocation.Latitude,
                        Longitude = item.GeoLocation.Longitude,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "SlhSngnl"
                    });

                }

                _context.SaveChangesAsync(System.Threading.CancellationToken.None);
            }

            return new IndexVM
            {
                IPAddress = model.IpAddress,
                OriginLocations = new Microsoft.AspNetCore.Mvc.Rendering.SelectList
                          (locationResponse.Data, "ID", "Name"),
                DestinationLocations = new Microsoft.AspNetCore.Mvc.Rendering.SelectList
                          (locationResponse.Data, "ID", "Name"),
                OriginID = locationResponse.Data[0].ID,
                DestinationID = locationResponse.Data[2].ID
            };
        }




        private Response PostRequest<Response>(IRequest requestModel, string url)
        {

            var restRequest = new RestRequest()
            {
                Method = Method.Post
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", $"{_appSettings.ApiClientToken}");
            restRequest.AddStringBody(JsonConvert.SerializeObject(requestModel), DataFormat.Json);

            var client = new RestClient(_appSettings.Url + url);
            var response = client.ExecuteAsync(restRequest);
            var returnResponse = JsonConvert.DeserializeObject<Response>(response.Result.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return returnResponse;
        }

        public SessionResponseModel GetSession(SessionModel model)
        {
            SessionRequestModel session = new SessionRequestModel()
            {
                Connection = new ConnectionModel { IpAddress = model.IpAddress, Port = model.Port },
                Browser = new BrowserModel { Name = model.BrowserName, Version = model.BrowserVersion },
                Type = model.Type
            };


            var response = PostRequest<SessionResponseModel>(session, _appSettings.GetSession);


            if (response.ResponseStatus != Models.ResponseStatus.Success)
                return null;

            var userSession = _context.Sessions.Where(x => x.ClientIP == model.IpAddress).FirstOrDefault();
            if (userSession == null)
            {
                _context.Sessions.Add(new Session
                {
                    ClientIP = model.IpAddress,
                    ClientPort = model.Port,
                    DeviceID = response.Data.DeviceID,
                    SessionID = response.Data.SessionID,
                    BrowserName = model.BrowserName,
                    BrowserVersion = model.BrowserVersion,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "SlhSngnl",
                });
            }
            else
            {
                userSession.ClientIP = model.IpAddress;
                userSession.ClientPort = model.Port;
                userSession.DeviceID = response.Data.DeviceID;
                userSession.SessionID = response.Data.SessionID;
                userSession.BrowserName = model.BrowserName;
                userSession.BrowserVersion = model.BrowserVersion;
                userSession.CreatedAt = DateTime.Now;
                userSession.CreatedBy = "SlhSngnl";

                _context.Sessions.Update(userSession);
            }

            _context.SaveChangesAsync(System.Threading.CancellationToken.None);
            return response;




        }
    }
}
