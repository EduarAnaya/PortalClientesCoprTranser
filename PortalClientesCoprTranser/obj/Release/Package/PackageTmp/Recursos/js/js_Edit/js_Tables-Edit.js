$(function () {
    var opcionies = {
        "scrollY": "30rem",
        "scrollCollapse": true
    }
    $('#table_FactPendientes').DataTable(opcionies);
    $('#table_FactVencidas').DataTable(opcionies);
    $('#table_EstCartera').DataTable(opcionies);
    $('#table_viajActuales').DataTable(opcionies);
})