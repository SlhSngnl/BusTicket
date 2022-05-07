// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



    $("#OriginID").select2();
    $("#DestinationID").select2();

    if (sessionStorage.getItem("DepartureDate") !== null) {
        $("#DepartureDate").val(JSON.parse(sessionStorage.getItem("DepartureDate")));
        $("#DestinationID").val(JSON.parse(sessionStorage.getItem("DestinationID")));
        $("#DestinationID").select2().val();
        $("#OriginID").val(JSON.parse(sessionStorage.getItem("OriginID")));
        $("#OriginID").select2().val();
    }



function exchangeLocations() {
    let destinationID = $("#DestinationID").select2().val()
    let originID = $("#OriginID").select2().val()

    $("#OriginID").val(destinationID);
    $("#DestinationID").val(originID);

    $("#DestinationID").select2().val()
    $("#OriginID").select2().val()
}

$("#btnSubmit").on('click', function (e) {

    if ($("#DestinationID").select2().val() == $("#OriginID").select2().val()) {
        e.preventDefault();
        alert("Kalkış ve Varış Noktaları Farklı Olmalıdır!");
    } else {
        sessionStorage.setItem("DepartureDate", JSON.stringify($("#DepartureDate").val()));
        sessionStorage.setItem("DestinationID", JSON.stringify($("#DestinationID").select2().val()));
        sessionStorage.setItem("OriginID", JSON.stringify($("#OriginID").select2().val()));
    }
});
