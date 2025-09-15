const now = new Date()
const today = new Date(now.getFullYear(), now.getMonth(), now.getDate())
// 15th two months prior
const minDate = new Date(today)
minDate.setDate(minDate.getDate())
//minDate.setDate(15)
// 15th in two months
const maxDate = new Date(today)
maxDate.setMonth(maxDate.getMonth() + 1)
//maxDate.setDate(15)

var app = new Vue({
    el: '#app',
    data: {
        RUTA: '',
        //RUTA: '',
        MensajeSistema: '',
        idServicio: 16,
        ID_USUARIO: sessionStorage.getItem('ID_USUARIO'),
        USUARIO: sessionStorage.getItem('USUARIO'),
        SERVER_URL: sessionStorage.getItem('SERVER_URL'),
        ID_SEDE: sessionStorage.getItem('ID_SEDE'),
        PAGINA: '@@Title',
        SPEECH: '',

        ID: 0,
        SN: '0',
        CONTACTO: 'SELECCIONAR',
        CUSTOMER_ID: '0',
        TELEFONO: '0',
        TIPO_GESTION: 'SELECCIONAR',
        CALIFICACION: 'SELECCIONAR',
        CONFORMIDAD: '',

        MOTIVO: 'SELECCIONAR',
        MOTIVO_1: 'SELECCIONAR',
        MOTIVO_2: 'SELECCIONAR',
        MOTIVO_3: 'SELECCIONAR',
        MOTIVO_4: 'SELECCIONAR',
        MOTIVO_5: 'SELECCIONAR',

        CANTIDAD_EQUIPOS: 'SELECCIONAR',
        ACEPTA_VISITA: 'SELECCIONAR',
        PLAN_ACTUALIZADO: 'SELECCIONAR',
        ACEPTA_UPGRADE: 'SELECCIONAR',
        MOTIVO_NO_UPGRADE: 'SELECCIONAR',

        RESULTADO: 'SELECCIONAR',
        RESULTADO_FINAL: '',
        RESPONSABILIDAD: 'SELECCIONAR',

        FULL_CLARO: 'SELECCIONAR',
        MOTIVO_FULL_CLARO: 'SELECCIONAR',

        VELOCIDAD: 'SELECCIONAR',
        RANGO: 'SELECCIONAR',
        RANGO_VELOCIDAD: 'SELECCIONAR',

        FECHA_DIA: '',
        FECHA_HORA: 'SELECCIONAR',
        FECHA_AGENDA: '',
        OBSERVACION: '',
        PLANTILLA: '',


        OFRECIMIENTO: 'SELECCIONAR',

        textoOfrecimiento: '',
        TipoMigracion: 'SELECCIONAR',
        TipoPlan: 'SELECCIONAR',
        TipoPlay: 'SELECCIONAR',
        Plan: '',
        Equipos: '',
        HorarioSugerido: 'SELECCIONAR',
        CampoCalculadora: '',
        SVA: '',
        TipoDescuento: 'SELECCIONAR',
        TipoServicio: 'SELECCIONAR',
        NroPuntos: 'SELECCIONAR',
        Paquete: 'SELECCIONAR',
        Periodo: 'SELECCIONAR',
        Estado: 'SELECCIONAR',
        EquiposAMover: 'SELECCIONAR',

        min: minDate,
        max: maxDate,
        GESTION: 'SELECCIONAR',
        VARIABLE: '0',

        mensaje: '',
        KitCliente: '',
        Costo: '',
        ComboAv: 'SELECCIONAR',
        NombreVia: '',
        Numero: '',
        ComboMz: 'SELECCIONAR',
        Mz: '',
        Lte: '',
        DireccionEntrega: '',
        TelRef1: '',
        Referencia: '',
        TelRef2: '',
        ComboDepartamento: 'SELECCIONAR',
        ComboProvincia: 'SELECCIONAR',
        ComboDistrito: 'SELECCIONAR',
        ComboTipoPago: 'SELECCIONAR',
        ObsMesh: '',

        Lista1: [],
        Lista2: [],
        Lista3: [],
        Lista4: [],
        Lista5: [],
        Lista6: [],
        Lista7: [],
        Lista8: [],
        Lista9: [],
        Lista10: [],
        Lista11: [],
        Lista12: [],
        Lista13: [],
        Lista14: [],
        Lista15: [],
        Lista16: [],
        Lista17: [],
        Lista18: [],
        Lista19: [],
        Lista20: [],
        Lista21: [],
        Lista25: [],

        Lista26: [],
        Lista27: [],
        Lista28: [],
        Lista29: [],
        Lista30: [],
        Lista31: [],
        Lista32: [],
        Lista33: [],
        Lista34: [],
        Lista35: [],

        Lista36: [],
        Lista37: [],
        Lista38: [],
        Lista39: [],
        Lista40: [],
        Lista41: [],

        Lista50: [],
        Lista51: [],
        Lista52: [],
        Lista53: [],
        Lista54: [],
        Lista55: [],
        Lista60: [],
        Lista61: [],
        Lista62: [],
        Lista63: [],
        Lista70: [],
        Lista71: [],
        ListaPrincipal: [],
        ListaSolucion: [],

        ListaResultadoAvance: [],
        isLoginTrue: false,
        isPanelAgente: false,
        isOtros: false,

        isCambioPlan: false,
        isSVA: false,
        isTipoCliente: false,
        isCambioTipoCliente: false,
        isDescuentoCargoFijo: false,
        isPuntoAdicional: false,
        isEquipoAMover: false,
        isActivacionCanales: false,
        isPeriodo: false,
        isBonosIncremento: false,
        isRefinanciamiento: false,
    },
    methods: {
        mostrarModal: function (form) {
            this.MensajeSistema = form.msg;
            this.$bvModal.show(form.modal);

        },
        mostrarToast(variant = null) {
            this.MensajeSistema = variant.msg;
            this.$bvToast.toast(this.MensajeSistema, {
                title: `Alerta de sistema`,
                variant: variant.toast,
                solid: true
            })
        },
        pantalla: function (item) {
            this.$bvModal.show(item.PANTALLA);
        },
        limpiarFormulario: function () {
            this.SPEECH = '';

            this.ID = 0;
            this.SN = '0';
            this.CONTACTO = '';
            this.CUSTOMER_ID = '0';
            this.TELEFONO = '0';
            this.TIPO_GESTION = 'SELECCIONAR';
            this.CALIFICACION = 'SELECCIONAR';
            this.CONFORMIDAD = '';

            this.FECHA_DIA = ''
            this.FECHA_HORA = 'SELECCIONAR';

            this.MOTIVO = 'SELECCIONAR';
            this.MOTIVO_1 = 'SELECCIONAR';
            this.MOTIVO_2 = { VALOR: 'NIGUNO' };
            this.MOTIVO_3 = { VALOR: 'NIGUNO' };
            this.MOTIVO_4 = { VALOR: 'NIGUNO' };
            this.MOTIVO_5 = { VALOR: 'NIGUNO' };

            this.CANTIDAD_EQUIPOS = 'SELECCIONAR';
            this.ACEPTA_VISITA = 'SELECCIONAR';
            this.VELOCIDAD = 'SELECCIONAR';
            this.RANGO = 'SELECCIONAR';
            this.RANGO_VELOCIDAD = 'SELECCIONAR';

            this.VELOCIDAD_CONTRADA = '';
            this.TEST_VELOCIDAD = '';
            this.RANGO_VELOCIDAD = '';
            this.EQUIPO_CORRECTO = '';

            this.PLAN_ACTUALIZADO = 'SELECCIONAR';
            this.ACEPTA_UPGRADE = '';
            this.MOTIVO_NO_UPGRADE = '';

            this.RESULTADO = 'SELECCIONAR';
            this.RESULTADO_FINAL = '';
            this.RESPONSABILIDAD = 'SELECCIONAR';
            this.OBSERVACION = '';
            this.PLANTILLA = '';
        },
        limpiarOfrecimiento: function () {
            this.OFRECIMIENTO = 'SELECCIONAR';

            this.textoOfrecimiento = '';
            this.TipoMigracion = 'SELECCIONAR';
            this.TipoPlan = 'SELECCIONAR';
            this.TipoPlay = 'SELECCIONAR';
            this.Plan = '';
            this.Equipos = '';
            this.HorarioSugerido = 'SELECCIONAR';
            this.CampoCalculadora = '';
            this.SVA = '';
            this.TipoDescuento = 'SELECCIONAR';
            this.TipoServicio = 'SELECCIONAR';
            this.NroPuntos = 'SELECCIONAR';
            this.Paquete = 'SELECCIONAR';
            this.Periodo = 'SELECCIONAR';
            this.Estado = 'SELECCIONAR';
            this.EquiposAMover = 'SELECCIONAR';

            this.KitCliente = '';
            this.Costo = '';
            this.ComboAv = 'SELECCIONAR';
            this.NombreVia = '';
            this.Numero = '';
            this.ComboMz = 'SELECCIONAR';
            this.Mz = '';
            this.Lte = '';
            this.DireccionEntrega = '';
            this.TelRef1 = '';
            this.Referencia = '';
            this.TelRef2 = '';
            this.ComboDepartamento = 'SELECCIONAR';
            this.ComboProvincia = 'SELECCIONAR';
            this.ComboDistrito = 'SELECCIONAR';
            this.ComboTipoPago = 'SELECCIONAR';
            this.ObsMesh = '';
        },
        cargarControles: function () {
            this.Lista1 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 1);

            this.Lista5 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 5);
            this.Lista6 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 6);
            this.Lista8 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 8);
            this.Lista9 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 9);
            this.Lista10 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 10);
            this.Lista11 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 11);
            this.Lista12 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 12);
            this.Lista13 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 13);
            this.Lista14 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 14);
            this.Lista15 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 15);
            this.Lista16 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 16);
            this.Lista17 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 17);
            this.Lista18 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 18);
            this.Lista19 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 19);
            this.Lista20 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 20);
            this.Lista25 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 25);
            this.Lista26 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 26);
            this.Lista27 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 27);
            this.Lista28 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 28);
            this.Lista29 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 29);


            this.Lista30 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 30);
            this.Lista31 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 31);
            this.Lista32 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 32);

            this.Lista35 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 35);
            this.Lista36 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 36);
            this.Lista37 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 37);
            this.Lista38 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 38);
            this.Lista39 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 39);
            this.Lista40 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 40);
            this.Lista41 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 41);

            this.Lista50 = []; this.Lista51 = []; this.Lista52 = []; this.Lista53 = []; this.Lista54 = []; this.Lista55 = [];

            this.Lista60 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 60);
            this.Lista61 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 61);
            this.Lista62 = []; this.Lista63 = [];
            this.Lista70 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 70);
            this.Lista71 = [];
        },
        cargarDropdow: function (item) {         //alert(JSON.stringify(lista));
            let idControl = item.ID_CONTROL + 1;
            let lista = [];
            lista = this.ListaPrincipal.filter(producto => producto.ID_DEPENDENCIA == item.ID);

            switch (idControl) {
                case 2: { this.Lista2 = lista; this.Lista3 = []; break; }
                case 3: { this.Lista3 = lista; break; }
                case 33: { this.Lista33 = lista; break; }
                case 34: { this.Lista34 = lista; break; }

                case 51: { this.Lista51 = lista; this.MOTIVO_1 = 'SELECCIONAR'; this.MOTIVO_2 = { VALUE: 'NIGUNO' }; this.MOTIVO_3 = { VALUE: 'NIGUNO' }; this.MOTIVO_4 = { VALUE: 'NIGUNO' }; this.MOTIVO_5 = { VALUE: 'NIGUNO' }; this.Lista52 = []; this.Lista53 = []; this.Lista54 = []; this.Lista55 = []; break; }
                case 52: { this.Lista52 = lista; this.MOTIVO_2 = { VALUE: 'NIGUNO' }; this.MOTIVO_3 = { VALUE: 'NIGUNO' }; this.MOTIVO_4 = { VALUE: 'NIGUNO' }; this.MOTIVO_5 = { VALUE: 'NIGUNO' }; this.Lista53 = []; this.Lista54 = []; this.Lista55 = []; break; }
                case 53: { this.Lista53 = lista; this.MOTIVO_3 = { VALUE: 'NIGUNO' }; this.MOTIVO_4 = { VALUE: 'NIGUNO' }; this.MOTIVO_5 = { VALUE: 'NIGUNO' }; this.Lista54 = []; this.Lista55 = []; break; }
                case 54: { this.Lista54 = lista; this.MOTIVO_4 = { VALUE: 'NIGUNO' }; this.MOTIVO_5 = { VALUE: 'NIGUNO' }; this.Lista55 = []; break; }
                case 55: { this.Lista55 = lista; this.MOTIVO_5 = { VALUE: 'NIGUNO' }; break; }

                case 62: { this.Lista62 = lista; this.ACEPTA_UPGRADE = { VALUE: 'NIGUNO' }; this.MOTIVO_NO_UPGRADE = { VALUE: 'NIGUNO' }; this.Lista63 = []; break; }
                case 63: { this.Lista63 = lista; this.MOTIVO_NO_UPGRADE = { VALUE: 'NIGUNO' }; break; }

                case 71: { this.Lista71 = lista; this.MOTIVO_FULL_CLARO = { VALUE: 'NIGUNO' }; break; }
            }
        },
        activarPreventiva: function () {   ///////////////////////////////////////////////////////////////
            this.ListaSolucion = [];
            this.limpiarFormulario();
            this.iniciar();
            this.cargarControles();
        },
        iniciar: function () {
            axios.post(this.SERVER_URL + '/api/Claro/AdministrarPreventiva', {
                USUARIO: this.USUARIO,
                ID: this.ID,
                TIPO: 1
            }).then(response => {
                if (response.data.ID > 0) {
                    this.ID = response.data.ID;
                    this.mostrarToast({ toast: 'info', msg: 'Iniciando un nuevo registro ...' });
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        },
        guardar: function () {
            if (this.TIPO_GESTION != 'SELECCIONAR' && this.SN.length > 15 && this.CALIFICACION != 'SELECCIONAR' && this.RESULTADO != 'SELECCIONAR' && this.RESPONSABILIDAD != 'SELECCIONAR') {
                this.MensajeSistema = "Verificar los siguientes campos: ";
                this.MensajeSistema = this.CUSTOMER_ID.length < 5 ? this.MensajeSistema + " Customer ID" : this.MensajeSistema;
                this.MensajeSistema = this.TELEFONO.length < 5 ? this.MensajeSistema + " Teléfono" : this.MensajeSistema;
                this.MensajeSistema = this.MOTIVO == 'SELECCIONAR' ? this.MensajeSistema + " Motivo" : this.MensajeSistema;
                this.MensajeSistema = this.MOTIVO_1 == 'SELECCIONAR' ? this.MensajeSistema + " Motivo" : this.MensajeSistema;


                this.MensajeSistema = this.VELOCIDAD_CONTRADA == 'SELECCIONAR' ? this.MensajeSistema + " Velocidad contrada" : this.MensajeSistema;
                this.MensajeSistema = this.TEST_VELOCIDAD == 'SELECCIONAR' ? this.MensajeSistema + " Cuanto marca Test de velocidad" : this.MensajeSistema;
                this.MensajeSistema = this.EQUIPO_CORRECTO == 'SELECCIONAR' ? this.MensajeSistema + " Equipo correcto" : this.MensajeSistema;

                this.MensajeSistema = this.ListaSolucion.length < 2 ? this.MensajeSistema + " Solución" : this.MensajeSistema;
  
                alert(this.FECHA_DIA);
                if (this.RESULTADO.VALUE == 'EN PROCESO') {
                    this.MensajeSistema = (this.FECHA_HORA == 'SELECCIONAR' || this.FECHA_DIA == '') ? this.MensajeSistema + " Fecha no valida" : this.MensajeSistema;
                    this.FECHA_AGENDA = this.FECHA_DIA + ' ' + this.FECHA_HORA;
                } else {
                    this.FECHA_AGENDA = '2021-01-01' + ' 00:00';
                }
                if (this.MensajeSistema.length > 34) {
                    this.mostrarToast({ toast: 'danger', msg: this.MensajeSistema });
                    return 0;
                } else {
                    let MOTIVO2 = this.MOTIVO_2.VALUE;
                    let MOTIVO3 = this.MOTIVO_3.VALUE;
                    let MOTIVO4 = this.MOTIVO_4.VALUE;
                    let MOTIVO5 = (this.MOTIVO_3.VALUE == 'ACEPTA TEST DE VELOCIDAD' ? this.VELOCIDAD.VALUE : this.MOTIVO_5.VALUE);
                    let MOTIVO6 = (this.MOTIVO_3.VALUE == 'ACEPTA TEST DE VELOCIDAD' ? this.RANGO.VALUE : 'NINGUNO');

                    this.generarPlantilla();

                        axios.post(this.SERVER_URL + '/api/Claro/AdministrarPreventiva', {
                            ID: this.ID,
                            SN: this.SN,
                            CONTACTO: this.CONTACTO.VALUE,
                            CUSTOMER_ID: this.CUSTOMER_ID,
                            TELEFONO: this.TELEFONO,
                            TIPO_GESTION: this.TIPO_GESTION.VALUE,
                            CALIFICACION: this.CALIFICACION.VALUE,
                            CONFORMIDAD: this.CONFORMIDAD,

                            MOTIVO: this.MOTIVO.VALUE,
                            MOTIVO_1: this.MOTIVO_1.VALUE,
                            MOTIVO_2: this.MOTIVO_2.VALUE,
                            MOTIVO_3: this.MOTIVO_3.VALUE,
                            MOTIVO_4: this.MOTIVO_4.VALUE,
                            MOTIVO_5: this.MOTIVO_5.VALUE,
                            //MOTIVO_6: MOTIVO6,

                            VELOCIDAD: this.VELOCIDAD.VALUE,
                            RANGO: this.RANGO.VALUE,
                            RANGO_VELOCIDAD: this.RANGO_VELOCIDAD,
                            CANTIDAD_EQUIPOS: this.CANTIDAD_EQUIPOS.VALUE,
                            PLAN_ACTUALIZADO: this.PLAN_ACTUALIZADO.VALUE,
                            ACEPTA_UPGRADE: this.ACEPTA_UPGRADE.VALUE,
                            MOTIVO_NO_UPGRADE: this.MOTIVO_NO_UPGRADE.VALUE,

                            RESULTADO: this.RESULTADO.VALUE,
                            RESULTADO_FINAL: this.RESULTADO_FINAL,
                            RESPONSABILIDAD: this.RESPONSABILIDAD.VALUE,
                            FULL_CLARO: this.FULL_CLARO.VALUE,
                            MOTIVO_FULL_CLARO: this.MOTIVO_FULL_CLARO.VALUE,

                            OBSERVACION: this.OBSERVACION,
                            PLANTILLA: this.PLANTILLA,
                            FECHA_AGENDA: this.FECHA_AGENDA,
                            USUARIO: this.USUARIO,
                            TIPO: 2

                        }).then(response => {
                            if (response.data.ID > 0) {
                                this.activarPreventiva();
                                this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                            } else {
                                this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                            }
                        }).catch(e => {
                            this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                        });
                }
            }
        },
        generarPlantilla: function () {
            let solucion = ''; let arma = '';
            
            for (var item in this.ListaSolucion) {
                if (`${this.ListaSolucion[item].ID_GRUPO}` == 1)
                { solucion = solucion   + `${this.ListaSolucion[item].OFRECIMIENTO}` + ' - '; }
                else { arma = arma      + `${this.ListaSolucion[item].OFRECIMIENTO}` + ' - '; }
            }
            solucion = solucion.slice(0, -2); arma = arma.slice(0, -2);

            this.PLANTILLA = "SIAC" + " | SN: " + this.SN + " | Contacto: " + this.CONTACTO.VALUE+" | Customer ID: " + this.CUSTOMER_ID + " | Teléfono: " + this.TELEFONO + " | Tipo gestión: " + this.TIPO_GESTION.VALUE + " | Calificación: " + this.CALIFICACION.VALUE + " | Conformidad: " + this.CONFORMIDAD +
                " | Motivo: " + this.MOTIVO.VALUE + " | Motivo 1: " + this.MOTIVO_1.VALUE + " | Motivo 2: " + this.MOTIVO_2.VALUE + " | Motivo 3: " + this.MOTIVO_3.VALUE + " | Motivo 4: " + this.MOTIVO_4.VALUE + " | Motivo 5: " + this.MOTIVO_5.VALUE +
                " | Velocidad: " + this.VELOCIDAD.VALUE, + " | Rango: " + this.RANGO.VALUE +" | Test velocidad: " + this.RANGO_VELOCIDAD + " | Cant. equipos conectados: " + this.CANTIDAD_EQUIPOS.VALUE +
                " | Plan actualizado: " + this.PLAN_ACTUALIZADO.VALUE + " | Acepta Upgrade: " + this.ACEPTA_UPGRADE.VALUE + " | Motivo no Upgrade: " + this.MOTIVO_NO_UPGRADE.VALUE +
                " | Solución: " + solucion + " | Arma: " + arma +
                " | Resultado: " + this.RESULTADO.VALUE + " | Resultado final: " + this.RESULTADO_FINAL + " | Responsabilidad: " + this.RESPONSABILIDAD.VALUE +
                " | Full Claro: " + this.FULL_CLARO.VALUE + " | Motivo Full Claro: " + this.MOTIVO_FULL_CLARO.VALUE +
                " | ObservaciÓn: " + this.OBSERVACION;
        },
        copiarPortaPreventiva: function () {
            var aux = document.createElement("input");
            this.generarPlantilla();
            aux.setAttribute("value", this.PLANTILLA);
            document.body.appendChild(aux);
            window.getSelection().removeAllRanges();
            aux.select();
            try {
                document.execCommand('copy');
                this.mostrarToast({ toast: 'info', msg: 'plantilla copiada' });
            }
            catch (ex) {
                excepcion();
            }
        },

        abrirOfrecimientos: function (item) {
            this.Lista21 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 21 && producto.OBSERVACION == item.Ofrecimiento);
            this.OFRECIMIENTO = 'SELECCIONAR';
            this.GESTION = 'SELECCIONAR';
            this.VARIABLE = '0';
            this.textoOfrecimiento = '';

            this.mostrarModal({ modal: 'formularioOfrecimiento', msg: item.Ofrecimiento });

        },
        validarCampoGestion: function () {
            this.VARIABLE = '0';
        },
        registrarOfrecimiento: function () {
            this.textoOfrecimiento = '';
            if (this.OFRECIMIENTO.VALUE != 'SELECCIONAR') {
                let msg = "Verificar los siguientes campos: ";
                let texto = '| ' + this.MensajeSistema + ': ' + this.OFRECIMIENTO.VALUE + ' | ';

                if (this.OFRECIMIENTO.SPEECH == 'SI') {
                    msg = this.GESTION == 'SELECCIONAR' ? msg + " Gestion" : msg;
                    texto = texto + this.GESTION.VALUE + "  ";
                    if (this.GESTION.SPEECH == 'SI') {
                        msg = this.VARIABLE.length < 8 ? msg + " Valor " + this.GESTION.VALUE : msg;
                        texto = texto + this.VARIABLE + "  ";
                    }
                }
                if (msg.length < 35) {
                    if (this.OFRECIMIENTO.VALUE == 'REPETIDOR MESH') {
                        msg = this.KitCliente.length < 3 ? msg + " Kit cliente" : msg;
                        msg = this.Costo.length < 1 ? msg + " Costo" : msg;
                        msg = this.ComboAv == 'SELECCIONAR' ? msg + " Av/Calle/Jr " : msg;
                        msg = this.NombreVia.length < 3 ? msg + " Nombre de la via" : msg;
                        msg = this.Numero.length < 3 ? msg + " Numero" : msg;
                        msg = this.ComboMz == 'SELECCIONAR' ? msg + " Mz/Bloq/Edif" : msg;
                        msg = this.DireccionEntrega.length < 3 ? msg + " Dirección entrega" : msg;
                        msg = this.TelRef1.length < 4 ? msg + " TelRef1" : msg;
                        msg = this.Referencia.length < 4 ? msg + " Referencia" : msg;
                        msg = this.TelRef2.length < 4 ? msg + " TelRef2" : msg;
                        msg = this.ComboDepartamento == 'SELECCIONAR' ? msg + " Departamento" : msg;
                        msg = this.ComboProvincia == 'SELECCIONAR' ? msg + " Provincia" : msg;
                        msg = this.ComboDistrito == 'SELECCIONAR' ? msg + " Distrito" : msg;
                        msg = this.ComboTipoPago == 'SELECCIONAR' ? msg + " TipoPago" : msg;

                        texto = texto + " | KitCliente: " + this.KitCliente + "  | Costo: " + this.Costo + "  | " + this.ComboAv.VALUE + ": " + this.NombreVia + " N° " + this.Numero + "  | " + this.ComboMz.VALUE + ": " + this.Mz + " Lte: " + this.Lte +
                            "  | Dirección entrega: " + this.DireccionEntrega + " Tel. Ref1: " + this.TelRef1 + "  | Referencia: " + this.Referencia + " Tel. Ref2: " + this.TelRef2 + "  | Ubigeo: " + this.ComboDepartamento.VALUE + " - " + this.ComboProvincia.VALUE + " - " + this.ComboDistrito.VALUE + "  | Tipo Pago: " + this.ComboTipoPago.VALUE + "  | ObservaciÓn: " + this.ObsMesh;
                    } else if (this.OFRECIMIENTO.VALUE == 'REFINANCIAMIENTO DE DEUDA') {
                        texto = texto + " | Monto " + this.CampoCalculadora;
                    } else if (this.OFRECIMIENTO.VALUE == 'ACTIVACIÓN DE SERVICIO DE VALOR AGREGADO') {
                        texto = texto + " | Monto " + this.SVA;
                    } else if (this.OFRECIMIENTO.VALUE == 'CAMBIO DE PLAN') {
                        texto = texto + " | Tipo Migración: " + this.TipoMigracion.VALUE;
                        texto = texto + " | Tipo Play: " + this.TipoPlay.VALUE;
                        texto = texto + " | Tipo plan: " + this.TipoPlan.VALUE;
                        texto = texto + " | Plan: " + this.Plan;
                        texto = texto + " | Equipos: " + this.Equipos;
                        texto = texto + " | Horario sugerido: " + this.HorarioSugerido;
                    } else if (this.OFRECIMIENTO.VALUE == 'DESCUENTO EN CARGO FIJO') {
                        texto = texto + " | Tipo descuento: " + this.TipoDescuento.VALUE;
                    } else if (this.OFRECIMIENTO.VALUE == 'PUNTO ADICIONAL SIN COSTO') {
                        texto = texto + " | Tipo servicio: " + this.TipoServicio.VALUE;
                        texto = texto + " | Nro puntos: " + this.NroPuntos.VALUE;
                    } else if (this.OFRECIMIENTO.VALUE == 'TRASLADO INTERNO SIN COSTO') {
                        texto = texto + " | Equipos a mover: " + this.EquiposAMover.VALUE;
                    } else if (this.OFRECIMIENTO.VALUE == 'ACTIVACIÓN DE CANALES PREMIUM') {
                        texto = texto + " | Paquete: " + this.Paquete.VALUE;
                        texto = texto + " | Periodo: " + this.Periodo.VALUE;
                    } else if (this.OFRECIMIENTO.VALUE == 'BONOS DE INCREMENTO DE VELOCIDAD TEMPORAL') {
                        texto = texto + " | Periodo: " + this.Periodo.VALUE;
                        texto = texto + " | Estado: " + this.Estado.VALUE;
                    }
                }

                if (msg.length < 35) {
                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarOfrecimiento', {
                        ID_SOURCE: this.ID,
                        OFRECIMIENTO: this.OFRECIMIENTO.VALUE,
                        GESTION: texto,
                        OBSERVACION: this.OBSERVACION,

                        USUARIO: this.USUARIO,
                        ID_GRUPO: (this.MensajeSistema == 'ARMA' ? 2 : 1),
                        TIPO: 2,
                    }).then(response => {
                        if (response.data.ID > 0) {
                            this.ListaSolucion.push({ ID: response.data.ID, OFRECIMIENTO: this.OFRECIMIENTO.VALUE, GESTION: texto, ID_GRUPO: this.MensajeSistema == 'ARMA' ? 2 : 1 })

                            this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                        } else {
                            this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                        }
                        this.$bvModal.hide('formularioOfrecimiento');
                    }).catch(e => {
                        this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                    });
                }
            }
        },
        eliminarOfrecimiento: function (item) {
            var opcion = confirm("Deseas eliminar el ofrecimiento - " + item.VALUE);
            if (opcion == true) {
                if (this.DNI_REGISTRO != 'NO REGISTRADO') {
                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarOfrecimiento', {
                        ID: item.ID,
                        USUARIO: this.USUARIO,
                        TIPO: '3'
                    }).then(response => {

                        if (response.data.ID > 0) {
                            this.ListaSolucion = this.ListaSolucion.filter(ofrecimiento => ofrecimiento.ID != item.ID);
                            this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                        } else {
                            this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                        }
                    }).catch(e => {
                        this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                    });
                }
            } else {
                this.mostrarToast({ toast: 'warning', msg: 'Cancelado por el usuario' });
            }
        },
        calificar: function (item) {
            this.SPEECH = '';
            this.RESULTADO = 'SELECCIONAR';
            this.RESPONSABILIDAD = 'SELECCIONAR';
            this.FECHA_DIA = ''
            this.FECHA_HORA = 'SELECCIONAR';

            this.CONFORMIDAD = item.OBSERVACION;
            this.SPEECH = item.SPEECH;

            this.Lista50 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 50 && producto.OBSERVACION == item.OBSERVACION);
            this.Lista51 = []; this.Lista52 = []; this.Lista53 = []; this.Lista54 = []; this.Lista55 = [];
            this.MOTIVO = 'SELECCIONAR'; this.MOTIVO_1 = 'SELECCIONAR'; this.MOTIVO_2 = { VALOR: 'NIGUNO' }; this.MOTIVO_3 = { VALOR: 'NIGUNO' }; this.MOTIVO_4 = { VALOR: 'NIGUNO' }; this.MOTIVO_5 = { VALOR: 'NIGUNO' };
            this.calcular();
        },
        calcular: function () {
            this.SPEECH = '';
            if (this.CALIFICACION != 'SELECCIONAR' && this.RESULTADO != 'SELECCIONAR') {
                if (this.RESULTADO.VALUE == 'EN PROCESO') {
                    this.RESULTADO_FINAL = 'SOLUCIÓN EN PROCESO';
                    this.SPEECH = 'Sr (a) XXX, le comento que tenemos un personal que se encargará de hacer seguimiento a todos nuestros ofrecimientos, por ello me podria brindar un numero de contacto para poder comunicarnos.';
                }
                else if (this.CALIFICACION.OBSERVACION == 'NO CONFORME' && this.RESULTADO.VALUE == 'TERMINADO') {
                    this.RESULTADO_FINAL = 'NO SOLUCIONADO';
                    this.SPEECH = 'Sr(a) XXX nos apena no haberlo podido ayudar, le agradezco su tiempo, lo atendio: XXXXX.';
                }
                else {
                    this.RESULTADO_FINAL = 'FIDELIZADO';
                    this.SPEECH = 'Sr. XXXX , agradecemos su tiempo. Lo atendio XXXX, que tenga buen (dia, tarde, noche).';
                }
            }
        },
        testVelocidad: function () {
            this.SPEECH = '';
            if (this.VELOCIDAD != 'SELECCIONAR' && this.RANGO != 'SELECCIONAR') {

                let valor = (parseFloat(this.RANGO.OBSERVACION) / parseFloat(this.VELOCIDAD.OBSERVACION) * 100).toFixed(0);
                if (valor >= 70) { this.RANGO_VELOCIDAD = 'MAYOR 70%'; }
                else if (valor >= 40) {
                    this.RANGO_VELOCIDAD = 'ENTRE 40% Y 70%';
                    this.SPEECH = 'Estimado Cliente, estamos validando que necesita una visita tecnica.';
                }
                else if (valor >= 0) {
                    this.RANGO_VELOCIDAD = 'MENOS DE 40%';
                    this.SPEECH = 'Estimado Cliente, estamos validando que necesita una visita tecnica.';
                }
                else { this.RANGO_VELOCIDAD = 'SIN RESULTADO'; }
            }
        },
        rangoVelocidad: function (item) {
            this.SPEECH = '';
            this.SPEECH = item.SPEECH;
        },
        responsabilidad: function (item) {
            this.SPEECH = item.SPEECH;
        },
        
        cargarOpciones: function () {
            axios.post(this.SERVER_URL + '/api/Opciones/ListarOpcionesCRM', {
                ID_GRUPO: this.idServicio,
                TIPO: 5,
            }).then(response => {
                this.ListaPrincipal = response.data;
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        }
    }
})
app.cargarOpciones();