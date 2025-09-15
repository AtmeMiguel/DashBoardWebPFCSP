const now = new Date()
const today = new Date(now.getFullYear(), now.getMonth(), now.getDate())
const minDate = new Date(today)
minDate.setMonth(minDate.getMonth())

var app = new Vue({
    el: '#app',
    data: {
        MensajeSistema: '',

        MENSAJE: '',
        idServicio: 16,
        ID_SESSION: sessionStorage.getItem('ID_SESSION'),
        ID_USUARIO: sessionStorage.getItem('ID_USUARIO'),
        USUARIO: sessionStorage.getItem('USUARIO'),
        NOMBRES: sessionStorage.getItem('NOMBRES'),
        APELLIDOS: sessionStorage.getItem('APELLIDOS'),
        SERVER_URL: sessionStorage.getItem('SERVER_URL'),
        ID_SEDE: sessionStorage.getItem('ID_SEDE'),
        PAGINA: '@@Title',

        SPEECH: '',
        show: false,
        fields: ['ID', 'FECHA_AGENDA', 'FECHA_REGISTRO', 'CUSTOMER_ID', 'OFRECIMIENTO', 'DNI_BO', 'AGENTE'],
        fieldsBO: ['ID', 'OFRECIMIENTO', 'GESTION', 'ESTADO', 'MOTIVO', 'FECHA'],
        ID: 0,
        ID_LIST: 0,
        ID_SOLUCION: 0,
        OFRECIMIENTO: '',
        GESTION: '',
        PLANTILLA: '',
        BO_Estado: '',
        BO_Motivo: '',
        BO_Motivo_II: '',
        MOTIVO_NO: '',
        NUEVA_SOT: '',
        NRO_TICKET: '',
        DEPARTAMENTO: '',
        FECHA: '',
        FECHA_HORA: 'SELECCIONAR',
        FECHA_AGENDA: '',
        OBSERVACION: '',
        min: minDate,

        TIPO_CONTACTO: '',
        CONFORMIDAD: '',
        RESULTADO: 'SELECCIONAR',
        SN_BO: '',
        MOTIVO: 'SELECCIONAR',
        MESH_RESULTADO: '',
        MESH_MOTIVO: '',


        ListaOfrecimiento: [],
        ListaPrincipal: [],
        ListaSolucion: [],
        ListaBandeja: [],
        ListaGeneral: [],

        Lista90: [],
        Lista91: [],
        Lista92: [],

        ListaResultadoAvance: [],
        ListaProceso: [],
        Columnas: ['ID', 'TITULO', 'RESULTADO', 'FECHA'],

        ListaProceso: [],
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


        CONTACTABILIDAD: 'SELECCIONAR',
        CONTACTABILIDAD_DETALLE: 'SELECCIONAR',
        SN: '0',
        CONTACTO: 'SELECCIONAR',
        CUSTOMER_ID: '0',
        TELEFONO: '0',
        TIPO_GESTION: 'SELECCIONAR',
        CALIFICACION: 'SELECCIONAR',
        CONFORMIDAD: '',

        RESULTADO_FINAL: '',
        RESPONSABILIDAD: 'SELECCIONAR',
        MOTIVO_RESPONSABILIDAD: 'SELECCIONAR',
        SUB_MOTIVO_RESPONSABILIDAD: 'SELECCIONAR',

        OFRECIMIENTO: 'SELECCIONAR',

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
        Lista80: [],
        Lista81: [],
        Lista97: [],
        Lista85: [],
        Lista86: [],
        Lista106: [],
    },
    methods: {
        mostrarModal: function (form) {
            this.MENSAJE = form.msg;
            this.$bvModal.show(form.modal);
        },
        mostrarToast(variant = null) {
            this.$bvToast.toast(variant.msg, {
                title: `Alerta de sistema`,
                variant: variant.toast,
                solid: true
            })
        },
        pantalla: function (item) {
            this.$bvModal.show(item.PANTALLA);
        },

        limpiarOfrecimiento: function () {
            this.TIPO_CONTACTO = { VALUE: 'NINGUNO' };
            this.CONFORMIDAD = { VALUE: 'NINGUNO' };
            this.RESULTADO = { VALUE: 'NINGUNO' };

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
            this.NRO_TICKET = '0';
            this.BO_Estado = { VALUE: 'NINGUNO' };
            this.BO_Motivo = { VALUE: 'NINGUNO' };
            this.BO_Motivo_II = { VALUE: 'NINGUNO' };
            this.MOTIVO_NO = { VALUE: 'NINGUNO' };
            this.NUEVA_SOT = '',
                this.MESH_RESULTADO = { VALUE: 'NINGUNO' };
            this.MESH_MOTIVO = { VALUE: 'NINGUNO' };
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

            this.Lista97 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 97);
            this.Lista90 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 90); this.Lista91 = []; this.Lista92 = [];

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
            //this.Lista20 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 20);
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
            this.Lista41 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 41); this.Lista42 = []; this.Lista43 = []

            this.Lista50 = []; this.Lista51 = []; this.Lista52 = []; this.Lista53 = []; this.Lista54 = []; this.Lista55 = [];

            this.Lista60 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 60);
            this.Lista61 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 61);
            this.Lista62 = []; this.Lista63 = [];
            this.Lista85 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 85); this.Lista86 = [];
            this.Lista106 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 106);

        },
        cargarDropdow: function (item) {         //alert(JSON.stringify(lista));
            let idControl = item.ID_CONTROL + 1;
            let lista = [];
            lista = this.ListaPrincipal.filter(producto => producto.ID_DEPENDENCIA == item.ID);

            switch (idControl) {
                case 23: { this.Lista23 = lista; this.BO_Motivo_II = { VALUE: 'NINGUNO' }; this.Lista24 = []; break; }
                case 24: { this.Lista24 = lista; this.MOTIVO_NO = { VALUE: 'NINGUNO' }; this.NUEVA_SOT = ''; break; }
                case 33: { this.Lista33 = lista; break; }
                case 34: { this.Lista34 = lista; break; }

                case 86: { this.Lista86 = lista; this.MESH_MOTIVO = { VALUE: 'NINGUNO' }; break; }
                case 91: { this.Lista91 = lista; this.RESULTADO = { VALUE: 'NINGUNO' }; this.Lista92 = []; break; }
                case 92: { this.Lista92 = lista; break; } 
            }

            if (item.ACCIONES.length > 3) {
                this.mostrarModal({ msg: item.ACCIONES, modal: 'formularioError' })

            }
        },
        coneccion: function (item) {
            axios.post(this.SERVER_URL + '/api/Usuarios/MantenimientoAsistencia', {
                ID: this.ID_SESSION,
                CONTENIDO: item.CONTENIDO,

                ID_CONTROL: item.ID,
                ID_USUARIO: this.ID_USUARIO,
                ID_GRUPO: this.idServicio,
                ID_SEDE: this.ID_SEDE,
                TIPO: 3,
            }).then(response => {
                if (response.data.ID > 0) {
                    sessionStorage.setItem('ID_SESSION', response.data.ID);
                    this.mostrarToast({ toast: 'success', msg: item.CONTENIDO });
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        },
         
        iniciar: function (item) {
            //this.limpiarFormulario();
            axios.post(this.SERVER_URL + '/api/Formulario/MantenimientoFormulario', {
                ID: 0,
                ID_USUARIO: this.ID_USUARIO,
                ID_SEDE: this.ID_SEDE,
                TIPO: 74,
            }).then(response => {
                if (response.data.ID > 0) {
                    this.ID = response.data.ID;
                    this.ID_LIST = response.data.RESULTADO;
                    this.cargarControles();

                    this.SPEECH = response.data.FECHA;
                    this.PLANTILLA = [];
                    let plantilla = response.data.PLANTILLA;
                    let separado = plantilla.split("|");
                    for (var f in separado) {
                        this.PLANTILLA.push({ name: separado[f] });
                    }

                    axios.post(this.SERVER_URL + '/api/Claro/ListarOfrecimiento', {
                        ID: this.ID,
                        TIPO: 4
                    }).then(response => {
                        if (response.data.length > 0) {
                            this.ListaOfrecimiento = response.data;
                            this.coneccion({ CONTENIDO: 'PRE. BOII | Gestion', ID: this.ID });
                        }
                    }).catch(e => {
                        this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                    });

                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarRetenciones', {
                        USUARIO: this.USUARIO,
                        ID: this.ID,
                        TIPO: 4
                    }).then(response => {
                        if (response.data.ID > 0) {
                        }
                    }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });

                } else {
                    this.mostrarToast({ toast: 'danger', msg: 'No cuenta con registros pendientes, validar con el supervisor ...' });
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'danger', msg: 'No cuenta con registros pendientes, validar con el supervisor ... ' });
            });
        },

        seguimiento: function (item) {
            axios.post(this.SERVER_URL + '/api/Claro/AdministrarOfrecimiento', {
                ID: item.ID,
                USUARIO: this.USUARIO,
                TIPO: 5
            }).then(response => {
                if (response.data.ID > 0) {
                    this.ID_SOLUCION = item.ID;
                    this.Lista22 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 22 && producto.DEPENDENCIA == item.OFRECIMIENTO);
                    this.Lista23 = []; this.Lista24 = [];
                    this.BO_Estado = { VALUE: 'NINGUNO' }; this.BO_Motivo = { VALUE: 'NINGUNO' }; this.BO_Motivo_II = { VALUE: 'NINGUNO' }; this.DEPARTAMENTO = { VALUE: 'NINGUNO' };
                    this.OBSERVACION = '';
                    this.NRO_TICKET = '';
                    this.OFRECIMIENTO = item.OFRECIMIENTO;
                    this.GESTION = item.GESTION;
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        },

        guardar: function () {
            let msg = 'Verificar los siguientes campos: ';
            let MotivoNoRecupero = '';
            if (this.BO_Estado.VALUE != 'NINGUNO' && this.BO_Motivo.VALUE != 'NINGUNO') {
                if (this.Lista24.length > 0) {
                    msg = this.BO_Motivo_II.VALUE == 'NINGUNO' ? msg + " BO_Motivo_II" : msg;
                    MotivoNoRecupero = (this.MOTIVO_NO.VALUE == 'NINGUNO') ? this.NUEVA_SOT : this.MOTIVO_NO.VALUE;
                }
                if (this.BO_Estado.VALUE == 'Seguimiento') {
                    msg = this.DEPARTAMENTO.VALUE == 'NINGUNO' ? msg + " DEPARTAMENTO" : msg;
                } else {
                    this.DEPARTAMENTO = { VALUE: 'NINGUNO' };
                }
                if (msg.length > 34) {
                    this.mostrarToast({ toast: 'danger', msg: msg });
                    return 0;
                } else {

                    this.OBSERVACION = 'Departamento: ' + this.DEPARTAMENTO.VALUE + ' - ' + this.OBSERVACION;

                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarOfrecimiento', {
                        ID: this.ID_SOLUCION,
                        ID_SOURCE: this.ID,
                        ESTADO: this.BO_Estado.VALUE,
                        MOTIVO: this.BO_Motivo.VALUE,
                        MOTIVO_II: this.BO_Motivo_II.VALUE,
                        OBSERVACION: this.OBSERVACION,
                        MESES: MotivoNoRecupero,
                        USUARIO: this.USUARIO,

                        TIPO: 6,
                    }).then(response => {
                        if (response.data.ID > 0) {
                            if (this.NRO_TICKET.length > 0) {
                                axios.post(this.SERVER_URL + '/api/Claro/AdministrarPreventiva', {
                                    ID: this.ID,
                                    OBSERVACION: this.NRO_TICKET,
                                    USUARIO: this.USUARIO,
                                    TIPO: 7

                                }).then(response => {
                                    if (response.data.ID > 0) {

                                    }
                                }).catch(e => {
                                    this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                                });
                            }
                            this.ListaOfrecimiento = this.ListaOfrecimiento.filter(i => i.ID != this.ID_SOLUCION);
                            this.ListaOfrecimiento.push({ ID: this.ID_SOLUCION, OFRECIMIENTO: this.OFRECIMIENTO, GESTION: this.GESTION, ESTADO: this.BO_Estado.VALUE, MOTIVO: this.BO_Motivo.VALUE, FECHA: 'AHORA', OBSERVACION: this.OBSERVACION })
                            this.ID_SOLUCION = 0;
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
         
        guardarBO: function () {
            let msg = 'Verificar los siguientes campos: ';
            let listaOfrecimientoPendiente = this.ListaOfrecimiento.filter(x => x.ESTADO == 'PENDIENTE');
            if (listaOfrecimientoPendiente.length < 1) {
                if (this.TIPO_CONTACTO.VALUE != 'NINGUNO' && this.CONFORMIDAD.VALUE != 'NINGUNO' && this.RESULTADO.VALUE != 'NINGUNO') {
                    if (this.TIPO_CONTACTO.VALUE == 'CONTACTO EFECTIVO' || this.TIPO_CONTACTO.VALUE == 'NO CONTACTO') {
                        msg = this.SN_BO.length < 16 ? msg + " SN BO" : msg;
                    }
                    if (this.RESULTADO.VALUE == 'EN PROCESO') {
                        msg = (this.FECHA == '' || this.FECHA_DIA == '') ? msg + " Fecha no valida" : msg;
                        this.FECHA_AGENDA = this.FECHA + ' ' + this.FECHA_HORA;
                    } else {
                        this.FECHA_AGENDA = '2021-01-01' + ' 00:00';
                    }
                    if (msg.length > 34) {
                        this.mostrarToast({ toast: 'danger', msg: msg });
                        return 0;
                    } else {
                        this.show = true;
                        axios.post(this.SERVER_URL + '/api/Claro/AdministrarPreventiva', {
                            ID: this.ID,
                            CONTACTABILIDAD: this.TIPO_CONTACTO.VALUE,
                            CONFORMIDAD: this.CONFORMIDAD.VALUE,
                            RESULTADO: this.RESULTADO.VALUE,
                            SN: this.SN_BO,
                            FECHA_AGENDA: this.FECHA_AGENDA,
                            USUARIO: this.USUARIO,
                            TIPO: 6
                        }).then(response => {
                            if (response.data.ID > 0) {
                                axios.post(this.SERVER_URL + '/api/Formulario/MantenimientoFormulario', {
                                    ID: this.ID_LIST,
                                    ID_SOURCE: this.ID,
                                    TITULO: this.USUARIO,
                                    ID_GRUPO: 0,
                                    ID_SEDE: this.ID_SEDE,
                                    ID_USUARIO: this.ID_USUARIO,
                                    TIPO: 70
                                }).then(response => {
                                    if (response.data.ID > 0) {
                                        if (this.RESULTADO.VALUE == 'EN PROCESO') {
                                            axios.post(this.SERVER_URL + '/api/Formulario/MantenimientoFormulario', {
                                                ID: this.ID,
                                                ID_SOURCE: this.ID,
                                                TITULO: '',
                                                CAMPO_1: this.FECHA_AGENDA,
                                                ID_GRUPO: 0,
                                                ID_SEDE: this.ID_SEDE,
                                                ID_USUARIO: this.ID_USUARIO,
                                                TIPO: 73
                                            }).then(response => {
                                                if (response.data.ID > 0) {
                                                    this.mostrarToast({ toast: 'success', msg: 'Agendando al backoffice' });
                                                    this.coneccion({ CONTENIDO: 'DISPONIBLE', ID: this.ID });
                                                    document.location.href = '../Claro/PreventivaBOII';
                                                }
                                            }).catch(e => {
                                            });
                                        } else {
                                            this.coneccion({ CONTENIDO: 'DISPONIBLE', ID: this.ID });
                                            document.location.href = '../Claro/PreventivaBOII';
                                            this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                                        }
                                    }
                                }).catch(e => {
                                });
                            } 
                        }).catch(e => {
                            this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                        });
                    }

                }
            } else { this.mostrarToast({ toast: 'warning', msg: 'Verificar estado de ofrecimientos' }); }

            


        },

        abrirOfrecimientos: function (item) {
            this.Lista21 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 21 && producto.OBSERVACION == item.Ofrecimiento);
            this.OFRECIMIENTO = 'SELECCIONAR';
            this.GESTION = 'SELECCIONAR';
            this.VARIABLE = '0';
            this.MensajeSistema = item.Ofrecimiento;
            this.mostrarModal({ modal: 'formularioOfrecimiento', msg: item.Ofrecimiento });
        },

        registrarOfrecimiento: function () {
            if (this.OFRECIMIENTO.VALUE != 'SELECCIONAR') {

                let msg = "Verificar los siguientes campos: ";
                let tipoDescuento = '';
                let meses = '';
                let texto = '| ' + this.MensajeSistema + ': ' + this.OFRECIMIENTO.VALUE + ' - ' + this.GESTION.VALUE + ' ' + this.VARIABLE + ' | ' +
                    ' Acepta MESH: ' + this.MESH_RESULTADO.VALUE + '-' + this.MESH_MOTIVO.VALUE;


                if (this.OFRECIMIENTO.SPEECH == 'SI' && this.OFRECIMIENTO.VALUE != 'REPETIDOR MESH') {
                    msg = this.GESTION == 'SELECCIONAR' ? msg + " Gestion" : msg;
                    if (this.GESTION.SPEECH == 'SI') {
                        msg = this.VARIABLE.length < 8 ? msg + " Valor " + this.GESTION.VALUE : msg;
                    }
                }
                if (this.OFRECIMIENTO.VALUE == 'REPETIDOR MESH') {
                    msg = this.MESH_RESULTADO.VALUE == 'NINGUNO' ? msg + " Resultado MESH" : msg;

                    if (this.MESH_RESULTADO.VALUE == 'SI') {
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
                    } else {
                        msg = this.MESH_MOTIVO.VALUE == 'NINGUNO' ? msg + " Motivo MESH" : msg;
                    }

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
                    texto = texto + " | Meses a aplicar: " + this.Plan;

                    tipoDescuento = this.TipoDescuento.VALUE;
                    meses = this.Plan;
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


                if (msg.length < 35) {
                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarOfrecimiento', {
                        ID_SOURCE: this.ID,
                        OFRECIMIENTO: this.OFRECIMIENTO.VALUE,
                        GESTION: texto,
                        OBSERVACION: this.OBSERVACION,
                        TIPO_DESCUENTO: tipoDescuento,
                        MESES: meses,
                        USUARIO: this.USUARIO,
                        ID_GRUPO: (this.MensajeSistema == 'ARMA' ? 2 : 1),
                        TIPO: 2,
                    }).then(response => {
                        if (response.data.ID > 0) {

                            this.ListaOfrecimiento.push({ ID: response.data.ID, OFRECIMIENTO: this.OFRECIMIENTO.VALUE, GESTION: texto, ESTADO: 'Pendiente', MOTIVO: 'Pendiente', FECHA: 'AHORA', OBSERVACION: '' });
                            this.limpiarOfrecimiento();
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
            } else {
                this.mostrarToast({ toast: 'warning', msg: 'Cancelado por el usuario' });
            }
        },

        agenda() {
            this.Lista20 = [];
            axios.post(this.SERVER_URL + '/api/Claro/ListarAgendamientos', {
                ID: this.ID,
                CONTENIDO: this.FECHA,
                USUARIO: this.USUARIO,
                TIPO: '4'
            }).then(response => {
                if (response.data.length > 0) {
                    this.Lista20 = response.data;
                    this.FECHA_HORA = '';
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        },
        Imprimir: function () {
            var arrData = this.ListaBandeja;

            var CSV = 'sep=,' + '\r\n\n';
            var row = "";
            for (var index in arrData[0]) {
                row += index + ',';
            }

            row = row.slice(0, -1);
            CSV += row + '\r\n';
            for (var i = 0; i < arrData.length; i++) {
                var row = "";
                for (var index in arrData[i]) {
                    row += '"' + arrData[i][index] + '",';
                }

                row.slice(0, row.length - 1);
                CSV += row + '\r\n';
            }

            if (CSV == '') {
                alert("Invalid data");
                return;
            }
            var fileName = "REPORTE";
            fileName += "_"; //ReportTitle.replace(/ /g, "_");
            var uri = 'data:text/csv;charset=utf-8,' + escape(CSV);
            var link = document.createElement("a");
            link.href = uri;
            link.style = "visibility:hidden";
            link.download = fileName + ".csv";
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        },
        cargarOpciones: function () {
            axios.post(this.SERVER_URL + '/api/Opciones/ListarOpcionesCRM', {
                ID_GRUPO: this.idServicio,
                TIPO: 5,
            }).then(response => {
                this.ListaPrincipal = response.data;
                this.limpiarOfrecimiento();
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        },
        
        eliminar: function (item) {
            var opcion = confirm("Deseas eliminar el item - " + item.TITULO + " del formulario " + item.RESULTADO);
            if (opcion == true) {
                axios.post(this.SERVER_URL + '/api/Excel/MantenimientoCarga', {
                    ID: item.ID,
                    ID_USUARIO: this.ID_USUARIO,
                    ID_SEDE: this.ID_SEDE,
                    TIPO: 19,
                }).then(response => {
                    if (response.data.ID > 0) {
                        this.ListaProceso = this.ListaProceso.filter(x => x.ID != item.ID);
                    }
                }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ... 2' }); });

            } else { this.mostrarToast({ toast: 'warning', msg: 'Cancelado por el usuario' }); }
        },

        listarGraficoGeneral: function () {
              
            axios.post(this.SERVER_URL + '/api/Excel/ListarCargasxPrograma', {
                ID: this.ID,
                ID_USUARIO: this.ID_USUARIO,
                ID_SEDE: this.ID_SEDE,
                TIPO: 17,
            }).then(response => {
                if (response.data.length > 0) {
                    this.ListaGeneral = []; this.graficoGeneral = []; this.graficoAvance2 = [];
                    let lista = response.data;
                    
                    let Pendiente = []; let Proceso = []; let Terminado = []; let Monitores = []; let Estudios = [];
                    Pendiente = lista.filter(x => x.ACCIONES == 'PENDIENTE');
                    Proceso = lista.filter(x => x.ACCIONES == 'PROCESO');
                    Terminado = lista.filter(x => x.ACCIONES == 'TERMINADO');

                    map = new Map();
                    for (let i of Pendiente) {
                        if (!map.has(i.RESULTADO)) {
                            map.set(i.RESULTADO, true);
                            Estudios.push({ ESTUDIO: i.RESULTADO });
                        }
                    }           //  alert(JSON.stringify(`${lista[items].ESTADO}`));

                    let uno = []; let grupos = { INC: 0 }; let registros = { INC: 0 };    //alert(i.ESTUDIO);
                    for (let i of Estudios) {
                        grupos = {};
                        registros = {};
                        let filas = lista.filter(x => x.RESULTADO == i.ESTUDIO);
                        if (filas.length > 0) {
                            grupos['GRAFICA'] = filas.length; //registros[i.ESTUDIO] = filas.length;
                            grupos['ESTUDIO'] = i.ESTUDIO;
                            uno.push(grupos);
                        }
                    }
                    this.ListaProceso = Proceso;
                    this.ListaGeneral.push({
                        PENDIENTE: Pendiente.length,
                        PROCESO: Proceso.length,
                        TERMINADO: Terminado.length,
                        TOTAL: lista.length,
                        MONITORES: Monitores.length,
                        ESTUDIOS: uno,
                        //ESTUDIOS: [
                        //    { ESTUDIO: "176 - TOYOTA VENTAS PERU", GRAFICA: { "NICOLAS": 33, "NANCY": 122 } },
                        //            { ESTUDIO: "175 - TOYOTA SERVICIOS PERU", GRAFICA: { "NICOLAS": 23, "NANCY": 10 } },
                        //    { ESTUDIO: "63 - IPSOS BCP_PYME SIN CARTERAS", GRAFICA: { "NICOLAS": 3, "NANCY": 2 } }]


                    });
                }
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ... 2' }); });
        }
    }
})
app.listarGraficoGeneral();
app.cargarOpciones();
