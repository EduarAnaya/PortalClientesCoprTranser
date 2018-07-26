$(function () {
    var opcionesDT = {
        showOn: "button",
        buttonImage: "../../Recursos/img/CalendarSVG.svg",
        buttonImageOnly: true,
        changeMonth: true,
        changeYear: true,
        dateFormat: "yy-mm-dd",
        yearRange: "-18: +0",
        maxDate: "+0m +0d"
    };

    $("#fecIni").datepicker(opcionesDT);
    $("#fecFin").datepicker(opcionesDT);
    $("#formMuestras").validate({
        rules: {
            fechaFin: {
                required: true,
                validarFecha: true
            }
        },
        messages: {
            datePick: {
                required: "Obligatorio!"
            }
        }
    });
    //VALIDAR DECIMALES (CARGA PROF LLANTAS)
    jQuery.validator.addMethod(
        "validarDecimal",
        function (value, element) {
            return this.optional(element) || /^(\d{1,2}\.\d{1})?$/.test(value); //#####,##
        },
        "Formato incorrectos!"
    );
    jQuery.validator.addMethod(
        "validarFecha",
        function (value, element) {
            return (
                this.optional(element) || /(^\d{2}[\/]\d{2}[\/]\d{4}$)/.test(value)
            );
        },
        "Formato incorrecto!"
    );

    /**
     *
     * ========================================================
     * VIEWS VIAJES
     *
     */
    //Viajes disponibles
    $("#table_viajActuales").on("click", "tr", function (e) {
        var idOrca = $(".idOrca", this).html();

        $.post("/Clientes/Viajes/detViajesCurso/", {
            nroOrca: idOrca
        }).done(function (Data) {
            $("#cont-tableViajesAct").removeClass("col-xl-12 col-lg-12");
            $("#cont-tableViajesAct").addClass("col-xl-9 col-lg-8");
            $("#cont-tableDetll").removeClass("visible");
            $("#card-bodyDetViajes").html("");
            $("#card-bodyDetViajes").html(Data);
            //document.location.href = "#cont-tableDetll";
        });
    });

    $("#btnHide").on("click", function () {
        $("#cont-tableDetll").addClass("visible");
        $("#cont-tableViajesAct").addClass("col-xl-12 col-lg-12");
        //document.location.href = "#cont-tableViajesAct";
    });
    //Historico de Viajes
    $("#frm-search-histo").on("submit", function (e) {
        e.preventDefault();
        var _FecIni = $("#fecIni").val();
        var _FecFin = $("#fecFin").val();
        $.post("/Clientes/Viajes/HistViajesSearch/", {
            _FecIni: _FecIni,
            _FecFin: _FecFin
        }).done(function (Data) {
            $("#cont-resultBusqueda").html("");
            $("#cont-resultBusqueda").html(Data);
        });
    });
    /*bicacion del viaje en el mapa */
    $("#table_viajActuales").on("click", ".geoPos", function (e) {
        $.get("/Clientes/Viajes/loadMapa/", {
            _orca: "eduar"
        }).done(function (data) {
            $("#exampleModalCenter").html(data);
            $("#exampleModalCenter").modal("show");
        });
    });
    $("#exampleModalCenter").on("shown.bs.modal", function (e) {
        LoadMap();
    });



    /**
     *
     * ========================================================
     * VIEWS FACTURACION
     *
     */
    //Historico de FActuras
    $("#frm-search-histoFacturas").on("submit", function (e) {
        e.preventDefault();
        var _FecIni = $("#fecIni").val();
        var _FecFin = $("#fecFin").val();
        $.post("/Clientes/Facturacion/SearchHistfacturas/", {
            _FecIni: _FecIni,
            _FecFin: _FecFin
        }).done(function (Data) {
            $("#cont-resultBusquedaFact").html("");
            $("#cont-resultBusquedaFact").html(Data);
        });
    });

    /**
     *
     * ========================================================
     * VIEWS ADMINISTRACION
     *
     */
    //Validar confirmar contraseña
    var password = $("inputPaswNew"),
        confirm_password = $("inputPaswNewConf");

    function validatePassword() {
        if (password.value != confirm_password.value) {
            confirm_password.setCustomValidity("Passwords Don't Match");
        } else {
            confirm_password.setCustomValidity('');
        }
    }
    password.onchange = validatePassword;
    confirm_password.onkeyup = validatePassword;
});