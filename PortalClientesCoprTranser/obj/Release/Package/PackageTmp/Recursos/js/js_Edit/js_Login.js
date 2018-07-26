$(function () {
    $('#selectOfic').on('change', function () {
        $("#codOfic").val(this.value);
    })
    $("#codOfic").blur(function (e) {
        $('#selectOfic').val($("#codOfic").val());
    });
    $("#selectOfic").val("");
})