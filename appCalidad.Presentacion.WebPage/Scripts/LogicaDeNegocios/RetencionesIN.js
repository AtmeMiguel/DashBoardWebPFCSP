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
        MensajeSistema: '',
        idServicio: 15,
        ID_SESSION: sessionStorage.getItem('ID_SESSION'),
        ID_USUARIO: sessionStorage.getItem('ID_USUARIO'),
        USUARIO: sessionStorage.getItem('USUARIO'),
        SERVER_URL: sessionStorage.getItem('SERVER_URL'),
        ID_SEDE: sessionStorage.getItem('ID_SEDE'),
        PAGINA: '@@Title',
        SPEECH: '',
        TITULO: '',
        MODAL: '',
        ID: 0,
        ID_LIST: 0,
        SIAC: 'SGA',
        SN: '0',
        TELEFONO: '0',
        PROYECTO: '0',
        CONTRATO: '0',
        CUSTOMER_ID: '0',
        TIPO_PRODUCTO: 'SELECCIONAR',
        MOTIVO: 'SELECCIONAR',
        SUB_MOTIVO: 'SELECCIONAR',
        SUB_MOTIVO_1: 'SELECCIONAR',
        SUB_MOTIVO_2: 'SELECCIONAR',


        MUDANZA_SINCOBERTURA: '',
        REFERENCIA_SINCOBERTURA: '',
        NIVEL6: 'SELECCIONAR',
        NIVEL7: 'SELECCIONAR',
        NIVEL8: 'SELECCIONAR',
        NIVEL9: 'SELECCIONAR',

        TIPO_GESTION: { VALUE: 'SELECCIONAR' },
        SUB_GESTION: { VALUE: 'SELECCIONAR' },
        TIPO_SOLICITUD: { VALUE: 'SELECCIONAR' },

        FULL_CLARO: { VALUE: 'NINGUNO' },
        MOTIVO_RAIZ: { VALUE: 'NINGUNO' },
        RESULTADO: { VALUE: 'SELECCIONAR' },
        COBERTURA: { VALUE: 'SELECCIONAR' },
        CODIGO_INTERACCION: '0', 

        OBSERVACION: '',
        PLANTILLA: '',
        CATEGORIA: '',
        min: minDate,
        max: maxDate,

        SOL: 0,
        ARMA: 0,
        MESH_RESULTADO: '',
        MESH_MOTIVO: '',

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



        mensaje: '',
        KitCliente: '',
        Costo: '0',
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
        Lista9: [],


        Lista25: [],
        Lista24: [],
        Lista30: [],
        Lista31: [],
        Lista32: [],
        Lista35: [],
        Lista10: [],
        Lista11: [],
        Lista12: [],
        Lista13: [],
        Lista14: [],
        Lista15: [],
        Lista17: [],
        Lista18: [],
        Lista19: [],
        Lista20: [],
        Lista26: [],
        Lista27: [],

        Lista33: [],
        Lista34: [],

        Lista36: [],
        Lista37: [],
        Lista38: [],
        Lista39: [],

        Lista40: [],
        Lista41: [],
        Lista42: [],

        Lista51: [],
        Lista52: [],
        Lista53: [],
        Lista54: [],
        Lista60: [],
        Lista85: [],
        Lista86: [],
        Lista87: [],
        Lista88: [],
        fields: [
            // A virtual column that doesn't exist in items
            'RESULTADO',
            // A column that needs custom formatting
            { key: 'PLANTILLA', label: 'ANOTACIONES' },
            // A regular column
            'FECHA'
        ],

        ListaPrincipal: [],
        ListaSolucion: [],
        ListaCustomerDataExterna: [],
        ListaCustomerAntiguo: [],
        ListaOfrecimientoAntiguo: [],


    },
    methods: {
        mostrarModal: function (form) {
            this.MensajeSistema = form.msg;
            this.$bvModal.show(form.modal);
        },

        mostrarModal2: function (form) {
            sessionStorage.setItem('ID_SOURCE', this.ID);
            sessionStorage.setItem('IMAGE', form.CONTENIDO);
            this.TITULO = form.msg;
            this.MODAL = form.PAGINA;
            this.$bvModal.show('formularioInterno');
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

        limpiarFormulario: function () {
            this.SPEECH = '';

            this.ID = 0;
            this.ID_LIST = 0;
            this.SIAC = 'SGA';
            this.SN = '';
            this.TELEFONO = '';
            this.PROYECTO = '0';
            this.CONTRATO = '';
            this.CUSTOMER_ID = '';

            this.TIPO_GESTION = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 };
            this.SUB_GESTION = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 };
            this.TIPO_SOLICITUD = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 };
            this.RESULTADO = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 };
            this.COBERTURA = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 };
            this.TIPO_PRODUCTO = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 };

            this.CODIGO_INTERACCION = '0';
            this.CATEGORIA = '';
            this.REFERENCIA_SINCOBERTURA = '';
            this.OBSERVACION = '';
            this.PLANTILLA = '';
            this.SOL = 0;
            this.ARMA = 0;

            this.FULL_CLARO = { VALUE: 'NINGUNO' };
            this.MOTIVO_RAIZ = { VALUE: 'NINGUNO' };

            this.limpiarMotivo();
            this.ListaSolucion = [];
            this.ListaCustomerDataExterna = [];
            this.ListaCustomerAntiguo = [];
            this.ListaOfrecimientoAntiguo = [];

        },
        limpiarMotivo: function () {
            this.MOTIVO = { VALUE: 'SELECCIONAR' };
            this.SUB_MOTIVO = { VALUE: 'SELECCIONAR' };
            this.SUB_MOTIVO_1 = { VALUE: 'SELECCIONAR' };
            this.SUB_MOTIVO_2 = { VALUE: 'SELECCIONAR' };

            this.MUDANZA_SINCOBERTURA = '';
            this.REFERENCIA_SINCOBERTURA = '';

            this.NIVEL6 = { VALUE: 'SELECCIONAR' };
            this.NIVEL7 = { VALUE: 'SELECCIONAR' };
            this.NIVEL8 = { VALUE: 'SELECCIONAR' };
            this.NIVEL9 = { VALUE: 'SELECCIONAR' };

            this.Lista36 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 36);
            this.Lista51 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 51);
            this.Lista37 = []; this.Lista38 = []; this.Lista39 = [];
            this.Lista52 = []; this.Lista53 = []; this.Lista54 = [];
        },
        limpiarOfrecimiento: function () {
            //this.OFRECIMIENTO = 'SELECCIONAR';
            this.MESH_RESULTADO = { VALUE: 'NINGUNO' };
            this.MESH_MOTIVO = { VALUE: 'NINGUNO' };

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
            this.Costo = '0';
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
            this.Lista2 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 2);
            this.Lista4 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 4); this.Lista5 = [];
            this.Lista25 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 25);
            this.Lista24 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 24);

            this.Lista40 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 40); this.Lista41 = []; this.Lista42 = [];

            // OFRECIMIENTOS
            this.Lista30 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 30);
            this.Lista31 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 31);
            this.Lista32 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 32);
            this.Lista35 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 35);

            this.Lista10 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 10);
            this.Lista11 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 11);
            this.Lista12 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 12);
            this.Lista13 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 13);
            this.Lista14 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 14);
            this.Lista15 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 15);
            this.Lista17 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 17);
            this.Lista18 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 18);
            this.Lista19 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 19);
            this.Lista20 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 20);
            this.Lista26 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 26);
            this.Lista27 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 27);
            this.Lista60 = [];
            this.Lista85 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 85); this.Lista86 = [];

            this.Lista87 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 87);
            this.Lista88 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 88);
        },

        cargarDropdow: function (item) {         //alert(JSON.stringify(lista));
            let idControl = item.ID_CONTROL + 1;
            let lista = [];
            lista = this.ListaPrincipal.filter(producto => producto.ID_DEPENDENCIA == item.ID);
            switch (idControl) {

                case 5: { this.Lista5 = lista; this.SUB_GESTION = { VALUE: 'SELECCIONAR' }; break; }
                case 33: { this.Lista33 = lista; break; }
                case 34: { this.Lista34 = lista; break; }

                case 41: { this.Lista41 = lista; this.Lista42 = []; this.SUB_GESTION.VALUE = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 }; this.TIPO_SOLICITUD = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 }; break; }
                case 42: { this.Lista42 = lista; this.TIPO_SOLICITUD = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 }; break; }
                //case 37: { this.Lista37 = lista; this.SUB_MOTIVO = { VALUE: 'SELECCIONAR' }; this.SUB_MOTIVO_1 = { VALUE: 'SELECCIONAR' }; this.SUB_MOTIVO_2 = { VALUE: 'SELECCIONAR' }; this.Lista38 = []; this.Lista39 = []; break; }
                //case 38: { this.Lista38 = lista; this.SUB_MOTIVO_1 = { VALUE: 'SELECCIONAR' }; this.SUB_MOTIVO_2 = { VALUE: 'SELECCIONAR' }; this.Lista39 = []; break; }
                //case 39: { this.Lista39 = lista; this.SUB_MOTIVO_2 = { VALUE: 'SELECCIONAR' }; break; }

                //case 52: { this.Lista52 = lista; this.NIVEL7 = { VALUE: 'SELECCIONAR' }; this.NIVEL8 = { VALUE: 'SELECCIONAR' }; this.NIVEL9 = { VALUE: 'SELECCIONAR' }; this.Lista53 = []; this.Lista54 = []; break; }
                //case 53: { this.Lista53 = lista; this.NIVEL8 = { VALUE: 'SELECCIONAR' }; this.NIVEL9 = { VALUE: 'SELECCIONAR' }; this.Lista54 = []; break; }
                //case 54: { this.Lista54 = lista; this.NIVEL9 = { VALUE: 'SELECCIONAR' }; break; }
                case 86: { this.Lista86 = lista; this.MESH_MOTIVO = { VALUE: 'NINGUNO' }; break; }
            }
            //if (item.ID_CONTROL == 2) {
            //    this.limpiarMotivo();
            //    if (item.VALUE == 'DTH') { this.Lista36.push({ ID: 100000, ID_CONTROL: 36, VALUE: 'MIGRACIÓN DE DTH A IPTV C161', ESTADO: 1, ID_DEPENDENCIA: 0, OBSERVACION: '', SPEECH: '', DESCARTES: '', ACCIONES: '' }) };
            //    if (item.VALUE == 'LTE') { this.Lista36.push({ ID: 100000, ID_CONTROL: 36, VALUE: 'MAYOR VELOCIDAD C161', ESTADO: 1, ID_DEPENDENCIA: 0, OBSERVACION: '', SPEECH: '', DESCARTES: '', ACCIONES: '' }) }
            //    if (item.VALUE == 'IFI') {
            //        this.Lista36.push({ ID: 100000, ID_CONTROL: 36, VALUE: 'MIGRACIÓN DE IFI A HFC - FTTH', ESTADO: 1, ID_DEPENDENCIA: 0, OBSERVACION: '', SPEECH: '', DESCARTES: '', ACCIONES: '' })
            //        this.Lista36.push({ ID: 100000, ID_CONTROL: 36, VALUE: 'RESTRICCIÓN DE MOVILIDAD', ESTADO: 1, ID_DEPENDENCIA: 0, OBSERVACION: '', SPEECH: '', DESCARTES: '', ACCIONES: '' })
            //        this.Lista36.push({ ID: 100000, ID_CONTROL: 36, VALUE: 'MAYOR VELOCIDAD C161', ESTADO: 1, ID_DEPENDENCIA: 0, OBSERVACION: '', SPEECH: '', DESCARTES: '', ACCIONES: '' })
            //    };
            //}


            if (this.TIPO_PRODUCTO.VALUE == 'IFI') {
                this.Lista42 = this.Lista42.filter(producto => producto.VALUE != 'BAJA PARCIAL');
            }

            if (item.ACCIONES.length > 3) {
                this.mostrarModal({ msg: item.ACCIONES, modal: 'formularioError' })
            }

        },
        cobertura: function () {
            this.COBERTURA = { VALUE: 'SELECCIONAR', ID_CONTROL: 0 };

            if (this.TIPO_PRODUCTO.VALUE == 'IFI' && this.RESULTADO.VALUE == 'NO RETENIDO') {
                this.Lista60 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 60);
            } else {
                this.Lista60 = []; 
            }
        },
        activar: function () {
            this.limpiarFormulario();
            this.iniciar();
            this.cargarControles();
        },
        coneccion: function (item) {
            this.ID_SESSION = sessionStorage.getItem('ID_SESSION');
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
                    //this.mostrarToast({ toast: 'success', msg: 'Mensaje confirmado' });
                }
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        },
        iniciar: function () {
            axios.post(this.SERVER_URL + '/api/Claro/AdministrarRetenciones', {
                USUARIO: this.USUARIO,
                ID: this.ID,
                TIPO: 1
            }).then(response => {
                if (response.data.ID > 0) {
                    this.ID = response.data.ID;
                    this.mostrarToast({ toast: 'info', msg: 'Iniciando un nuevo registro ...' });
                    this.coneccion({ CONTENIDO: 'RETE. IN | Gestión', ID: this.ID });
                    this.onList(); 
                }
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        },
        onList: function () {
            axios.post(this.SERVER_URL + '/api/Formulario/MantenimientoFormulario', {
                ID: 0,
                ID_SOURCE: this.ID,
                TITULO: '',
                ID_GRUPO: this.idServicio,
                ID_SEDE: this.ID_SEDE,
                ID_USUARIO: this.ID_USUARIO,
                TIPO: 70
            }).then(response => { 
                if (response.data.ID > 0) {
                    this.ID_LIST = response.data.ID;
                    //alert('inicio lista ' +this.ID_LIST);
                }
            }).catch(e => {
            });
        },


        offList: function () {
            axios.post(this.SERVER_URL + '/api/Formulario/MantenimientoFormulario', {
                ID: this.ID_LIST,
                ID_SOURCE: this.ID,
                TITULO: this.CAMPO, 
                ID_GRUPO: this.idServicio,
                ID_SEDE: this.ID_SEDE,
                ID_USUARIO: this.ID_USUARIO,
                TIPO: 70
            }).then(response => {
                if (response.data.ID > 0) {
                    //alert('fin lista ' + this.ID_LIST);
                    this.ID_LIST = 0;
                }
            }).catch(e => {
            });
        },
        guardar: function () {
            let msg = 'Verificar los siguientes campos: ';
            if (this.TIPO_GESTION.VALUE != 'SELECCIONAR' && this.SUB_GESTION.VALUE != 'SELECCIONAR' && this.SN.length > 15 && this.CUSTOMER_ID.length > 3 && this.TELEFONO.length > 8) {
                if (this.SUB_GESTION.DEPENDENCIA == 'SI') {
                    msg = this.TIPO_PRODUCTO.VALUE == 'SELECCIONAR' ? msg + " Tipo producto" : msg;
                } 
                if (this.RESULTADO.VALUE == 'NO RETENIDO') {
                    msg = this.REFERENCIA_SINCOBERTURA.length < 5 ? msg + " Dirección de recojo" : msg;
                }
                if (this.TIPO_PRODUCTO.VALUE == 'IFI' && this.RESULTADO.VALUE == 'NO RETENIDO') {
                    msg = this.COBERTURA.VALUE == 'SELECCIONAR' ? msg + " Cobertura" : msg;
                }

                if (this.TIPO_GESTION.VALUE == 'SOLICITUD') {
                    let solucion = 0; let arma = 0; let mesh = 'NO';
                    for (var ofre in this.ListaSolucion) {
                        if (this.ListaSolucion[ofre].OFRECIMIENTO == 'REPETIDOR MESH') {
                            mesh = 'SI';
                        }

                        if (`${this.ListaSolucion[ofre].ID_GRUPO}` == 1) {
                            solucion = solucion + 1;
                        }
                        else {
                            arma = arma + 1;
                        }
                    }
                    if (solucion < 1 || arma < 1) { msg = msg + " Solución y Arma"; }
                    if (mesh == 'NO') { msg = msg + " Ingresar ofrecimiento MESH"; }
                    msg = this.RESULTADO.VALUE == 'SELECCIONAR' ? msg + " Resultado" : msg;
                    msg = this.CODIGO_INTERACCION.length < 3 ? msg + " Código interacción" : msg;
                }

                if (msg.length > 34) {
                    this.mostrarToast({ toast: 'danger', msg: msg });
                } else {
                    this.CAMPO = this.CUSTOMER_ID;
                    this.generarPlantilla();
                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarRetenciones', {
                        ID: this.ID,
                        SN: this.SN,
                        SIAC: this.SIAC,
                        CUSTOMER_ID: this.CUSTOMER_ID,
                        TELEFONO: this.TELEFONO,
                        PROYECTO: this.PROYECTO,
                        CONTRATO: this.CONTRATO,

                        TIPO_PRODUCTO: this.TIPO_PRODUCTO.VALUE,
                        TIPO_GESTION: this.TIPO_GESTION.VALUE,
                        SUB_GESTION: this.SUB_GESTION.VALUE,
                        TIPO_SOLICITUD: this.TIPO_SOLICITUD.VALUE,
                        RESULTADO: this.RESULTADO.VALUE,
                        COBERTURA: this.COBERTURA.VALUE,
                        CODIGO_INTERACCION: this.CODIGO_INTERACCION,
                        REFERENCIA_SINCOBERTURA: this.REFERENCIA_SINCOBERTURA,

                        OBSERVACION: this.OBSERVACION,
                        PLANTILLA: this.PLANTILLA,
                        USUARIO: this.USUARIO,
                        TIPO: 2
                    }).then(response => {
                        if (response.data.ID > 0) { 
                            this.offList();
                            axios.post(this.SERVER_URL + '/api/Formulario/MantenimientoFormulario', {
                                ID: this.ID,
                                ID_SOURCE: this.ID,
                                TITULO: '',
                                ID_GRUPO: 0,
                                ID_SEDE: this.ID_SEDE,
                                ID_USUARIO: this.ID_USUARIO,
                                TIPO: 71
                            }).then(response => {
                                if (response.data.ID > 0) {
                                    //alert('lista backoffice ' + response.data.ID);
                                    this.coneccion({ CONTENIDO: 'DISPONIBLE', ID: this.ID });
                                    this.activar();
                                    this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                                }
                            }).catch(e => {
                            });
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
                if (`${this.ListaSolucion[item].ID_GRUPO}` == 1) {
                    solucion = solucion + `${this.ListaSolucion[item].OFRECIMIENTO}` + ' - ';
                }
                else {
                    arma = arma + `${this.ListaSolucion[item].OFRECIMIENTO}` + ' - '; 
                }
            } 
            solucion = solucion.slice(0, -2); arma = arma.slice(0, -2);
            this.PLANTILLA = "SN: " + this.SN + ' | ' + this.SIAC + " | Customer ID: " + this.CUSTOMER_ID + " | Teléfono: " + this.TELEFONO + " | Proyecto: " + this.PROYECTO + " | Contrato: " + this.CONTRATO + " | Tipo producto: " + this.TIPO_PRODUCTO.VALUE + " | Motivo: " + this.MOTIVO.VALUE +
                " | Tipo gestión: " + this.TIPO_GESTION.VALUE + " | Sub gestión: " + this.SUB_GESTION.VALUE + " | Tipo solicitud: " + this.TIPO_SOLICITUD.VALUE + " | Resultado: " + this.RESULTADO.VALUE + " | Dirección de recojo: " + this.REFERENCIA_SINCOBERTURA +  " | Cobertura: " + this.COBERTURA.VALUE + " | Codigo interacción: " + this.CODIGO_INTERACCION + 
                //" | Motivo: " + this.MOTIVO.VALUE + " | Motivo 1: " + this.SUB_MOTIVO.VALUE + " | Motivo 2: " + this.SUB_MOTIVO_1.VALUE + " | Motivo 3: " + this.SUB_MOTIVO_2.VALUE +
                //" | Motivo final: " + this.NIVEL6.VALUE + " | Motivo 1: " + this.NIVEL7.VALUE + " | Motivo 2: " + this.NIVEL8.VALUE + " | Motivo 3: " + this.NIVEL9.VALUE +
                //" | Sin cobertura : " + this.MUDANZA_SINCOBERTURA + " | Referencial: " + this.REFERENCIA_SINCOBERTURA + 
                " | Solución: " + solucion + " | Arma: " + arma +
                " | Usuario: " + this.USUARIO + " | Observación: " + this.OBSERVACION;
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
        guardarFullClaro: function () {
            axios.post(this.SERVER_URL + '/api/Formulario/MantenimientoFormulario', {
                ID: this.ID,
                ID_SOURCE: this.ID,
                TITULO: this.MOTIVO_RAIZ.VALUE,
                ID_GRUPO: 70,
                ID_SEDE: this.ID_SEDE,
                ID_USUARIO: this.ID_USUARIO,
                TIPO: 52
            }).then(response => {
                if (response.data.ID > 0) {
                    axios.post(this.SERVER_URL + '/api/Formulario/MantenimientoFormularioCRM', {
                        ID: response.data.ID,
                        ID_SOURCE: this.ID,
                        CONTENIDO: this.MOTIVO_RAIZ.VALUE,
                        CAMPO: this.USUARIO,
                        ID_GRUPO: 70,
                        ID_SEDE: this.ID_SEDE,
                        ID_USUARIO: this.ID_USUARIO,
                        TIPO: 52
                    }).then(response => {
                        if (response.data.ID > 0) {
                            this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                        } else {
                            this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                        }
                    }).catch(e => {
                    });
                }
            }).catch(e => {
            });
        },

        busquedaCustomerID: function () {       //  alert(JSON.stringify(this.ListaMaestra));
            this.ListaCustomerAntiguo = [];
            this.ListaOfrecimientoAntiguo = [];
            this.ListaCustomerDataExterna = [];
            this.CATEGORIA = '';
            this.ListaCustomerDataExterna.push({ ID: 0, RESULTADO: 'No hay resultado', PLANTILLA: 'No hay resultado' })
            if (this.CUSTOMER_ID.length > 3) {
                axios.post(this.SERVER_URL + '/api/Claro/ListarCustomerAntiguos', {
                    Customer_ID: this.CUSTOMER_ID,
                    TIPO: 10
                }).then(response => {
                    if (response.data.length > 0) {
                        this.ListaCustomerAntiguo = response.data;

                        let ofrecimientos = response.data.RESULTADO == 'RETENIDO' ? 'Ofrecimiento: ' : 'Ofrecido:';

                    }
                }).catch(e => {
                    this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                });
                axios.post(this.SERVER_URL + '/api/Claro/ListarCustomerAntiguos', {
                    Customer_ID: this.CUSTOMER_ID,
                    TIPO: 11
                }).then(response => {
                    if (response.data.length > 0) {
                        this.ListaCustomerDataExterna = response.data;
                        this.CATEGORIA = response.data.RESULTADO;
                    }
                }).catch(e => {
                    // this.mostrarModal({ modal: 'formularioError', msg: 'Ocurrio un error en la conexión búsqueda' });
                });
                axios.post(this.SERVER_URL + '/api/Claro/ListarCustomerAntiguos', {
                    Customer_ID: this.CUSTOMER_ID,
                    TIPO: 12
                }).then(response => {
                    if (response.data.length > 0) {
                        this.ListaOfrecimientoAntiguo = response.data;
                    }
                }).catch(e => {
                    // this.mostrarModal({ modal: 'formularioError', msg: 'Ocurrio un error en la conexión búsqueda' });
                });
            }
        },
        abrirOfrecimientos: function (item) {
            let solucion = 0; let arma = 0;
            for (var ofre in this.ListaSolucion) {
                if (`${this.ListaSolucion[ofre].ID_GRUPO}` == 1) {
                    //solucion = solucion + `${this.ListaSolucion[I].OFRECIMIENTO}` + ' - ';
                    solucion = solucion + 1;
                }
                else {
                    //arma = arma + `${this.ListaSolucion[I].OFRECIMIENTO}` + ' - ';
                    arma = arma + 1;
                }
            }
            if ((item.Ofrecimiento == 'SOLUCIÓN' && solucion > 2) || (item.Ofrecimiento == 'ARMA' && arma > 2)) {
                this.mostrarToast({ toast: 'warning', msg: 'limite excedido ...' });
            } else {
                this.Lista9 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 9 && producto.DEPENDENCIA == item.Ofrecimiento);
                for (var i in this.ListaCustomerDataExterna) {
                    if (this.ListaCustomerDataExterna[i].ID == 0) {
                        this.Lista9 = this.Lista9.filter(producto => producto.VALUE != 'HERRAMIENTA COBRANZAS 30%');
                        this.Lista9 = this.Lista9.filter(producto => producto.VALUE != 'HERRAMIENTA COBRANZAS 60%');
                    }
                }
                this.OFRECIMIENTO = 'SELECCIONAR';
                this.mostrarModal({ modal: 'formularioOfrecimiento', msg: item.Ofrecimiento });
            }
        },
        registrarOfrecimiento: function () {
            if (this.OFRECIMIENTO.VALUE != 'SELECCIONAR') {
                let msg = "Verificar los siguientes campos: ";
                let tipoDescuento = '';
                let meses = '';
                let texto = '| ' + this.MensajeSistema + ': ' + this.OFRECIMIENTO.VALUE + ' | ' + ' Resultado MESH: ' + this.MESH_RESULTADO.VALUE + '-' + this.MESH_MOTIVO.VALUE + ' | ';

                if (this.OFRECIMIENTO.VALUE == 'REPETIDOR MESH') {
                    msg = this.MESH_RESULTADO.VALUE == 'NINGUNO' ? msg + " Resultado MESH" : msg;

                    if (this.MESH_RESULTADO.VALUE == 'ACEPTA') {
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
                    } else if (this.MESH_RESULTADO.VALUE == 'NO ACEPTA') {
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
                    texto = texto + " | Numero caso: 00" + this.Plan;
                    texto = texto + " | No impacto descuento recibo " + this.Costo;
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
                } else if (this.OFRECIMIENTO.VALUE == 'HERRAMIENTA COBRANZAS 30%' || this.OFRECIMIENTO.VALUE == 'HERRAMIENTA COBRANZAS 60%') {
                    texto = texto + " | Tipo ofrecimiento: " + this.TipoDescuento.VALUE;
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
                            this.ListaSolucion.push({ ID: response.data.ID, OFRECIMIENTO: this.OFRECIMIENTO.VALUE, GESTION: texto, ID_GRUPO: this.MensajeSistema == 'ARMA' ? 2 : 1 })
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