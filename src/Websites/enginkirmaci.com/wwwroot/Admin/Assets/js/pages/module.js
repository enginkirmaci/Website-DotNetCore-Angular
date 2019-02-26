$(function () {
    var typeSelector = $("#typeSelector");

    typeChange(typeSelector.data("selected"));

    typeSelector.change(function () {
        typeChange(this.value);
    });
});

function typeChange(value) {
    $("#inputTitle").show();
    $("#inputText").show();

    $("#divSettings").hide();

    switch (value) {
        case 2: //PageList
            $("#inputText").hide();
            $("#divSettings").show();
            break;

        case 3: //Gallery
            $("#inputTitle").hide();
            break;
    }
}