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
const maxDate15 = new Date(today)
maxDate15.setDate(maxDate15.getDate() + 20)

var app = new Vue({
    el: '#app',
    data: {
        options: [
            { value: 'A', text: 'Option A (from options prop)', variant: 'alert-danger' },
            { value: 'B', text: 'Option B (from options prop)', variant: 'alert-info' }
        ],
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
        TITULO: '',
        MODAL: '',
        ID: 0,
        SIAC: '',
        CONTACTABILIDAD: 'SELECCIONAR',
        CONTACTABILIDAD_DETALLE: 'SELECCIONAR',
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
         
        RESULTADO: { VALUE: 'SELECCIONAR' },
        RESULTADO_FINAL: '',
        RESPONSABILIDAD: 'SELECCIONAR',
        MOTIVO_RESPONSABILIDAD: 'SELECCIONAR',
        SUB_MOTIVO_RESPONSABILIDAD: 'SELECCIONAR',

        FULL_CLARO: { VALUE: 'SELECCIONAR' },
        MOTIVO_FULL_CLARO: { VALUE: 'NINGUNO' },
        FC: { VALUE: 'NINGUNO' },
        MOTIVO_RAIZ: { VALUE: 'NINGUNO' },

        VELOCIDAD: 'SELECCIONAR',
        RANGO: 'SELECCIONAR',
        RANGO_VELOCIDAD: 'SELECCIONAR',

        MESH_RESULTADO: '',
        MESH_MOTIVO: '',


        FECHA_DIA: '',
        FECHA_HORA: 'SELECCIONAR',
        FECHA_AGENDA: '',
        context: null,
        OBSERVACION: '',
        PLANTILLA: '',


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

        min: minDate,
        max: maxDate,
        max15: maxDate15,
        GESTION: 'SELECCIONAR',
        VARIABLE: '0',

        Marca: '',
        Modelo: '',
        Cantidad: '',
        NroPedido: '',
        FechaEntrega: '',
        ComboDepartamento: 'SELECCIONAR',
        ComboProvincia: 'SELECCIONAR',
        ComboDistrito: 'SELECCIONAR',
        ComboTipoPago: 'SELECCIONAR',
        DireccionEntrega: '',


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
        Lista85: [],
        Lista86: [],
        Lista87: [],
        Lista88: [],
        Lista105: [],

        ListaCustomerAntiguo: [],
        ListaOfrecimientoAntiguo: [],
        ListaCustomerDataExterna: [],
        ListaCustomerDataExterna: [],
        CATEGORIA: '',
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
            this.MENSAJE = form.msg;
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
        dateDisabled(ymd, date) {
            // Disable weekends (Sunday = `0`, Saturday = `6`) and
            // disable days that fall on the 13th of the month
            const weekday = date.getDay()
            const day = date.getDate()
            // Return `true` if the date should be disabled
            return weekday === 0 || weekday === 6 || day === 13
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
                    TIPO: 16
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
        limpiarFormulario: function () {
            this.SPEECH = '';
            this.ListaCustomerAntiguo = [];
            this.ListaOfrecimientoAntiguo = [];
            this.ListaCustomerDataExterna = [];
            this.CATEGORIA = '';

            this.ID = 0;
            this.CONTACTABILIDAD = { VALUE: 'SELECCIONAR' };
            this.CONTACTABILIDAD_DETALLE = { VALUE: 'SELECCIONAR' };
            this.SN = '';
            this.CONTACTO = '';
            this.CUSTOMER_ID = '';
            this.TELEFONO = '';
            this.TIPO_GESTION = { VALUE: 'SELECCIONAR' };
            this.CALIFICACION = { VALUE: 'SELECCIONAR' };
            this.CONFORMIDAD = '';
            this.FULL_CLARO = { VALUE: 'SELECCIONAR' };
            this.MOTIVO_RAIZ = { VALUE: 'NINGUNO' };

            this.FECHA_DIA = '';
            this.FECHA_HORA = '';

            this.MOTIVO = { VALUE: 'NINGUNO', ID_CONTROL: 0 };
            this.MOTIVO_1 = { VALUE: 'NINGUNO', ID_CONTROL: 0 };
            this.MOTIVO_2 = { VALUE: 'NINGUNO', ID_CONTROL: 0 };
            this.MOTIVO_3 = { VALUE: 'NINGUNO', ID_CONTROL: 0 };
            this.MOTIVO_4 = { VALUE: 'NINGUNO', ID_CONTROL: 0 };
            this.MOTIVO_5 = { VALUE: 'NINGUNO', ID_CONTROL: 0 };

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
            this.ACEPTA_UPGRADE = { VALUE: 'NINGUNO' };
            this.MOTIVO_NO_UPGRADE = { VALUE: 'NINGUNO' };
             
            this.RESULTADO = { VALUE: 'SELECCIONAR' };
            this.RESULTADO_FINAL = '';
            this.RESPONSABILIDAD = { VALUE: 'NINGUNO' };
            this.MOTIVO_RESPONSABILIDAD = { VALUE: 'NINGUNO' };
            this.SUB_MOTIVO_RESPONSABILIDAD = { VALUE: 'NINGUNO' };


            this.OBSERVACION = '';
            this.PLANTILLA = '';
        },
        limpiarOfrecimiento: function () {
            //this.OFRECIMIENTO = 'SELECCIONAR';

            this.TipoMigracion = 'SELECCIONAR';
            this.TipoPlan = 'SELECCIONAR';
            this.TipoPlay = 'SELECCIONAR';
            this.Plan = '';
            this.Equipos = '';
            this.HorarioSugerido = '';
            this.CampoCalculadora = '';
            this.SVA = '';
            this.TipoDescuento = 'SELECCIONAR';
            this.TipoServicio = 'SELECCIONAR';
            this.NroPuntos = 'SELECCIONAR';
            this.Paquete = 'SELECCIONAR';
            this.Periodo = 'SELECCIONAR';
            this.Estado = 'SELECCIONAR';
            this.EquiposAMover = 'SELECCIONAR';

            this.MESH_RESULTADO = { VALUE: 'NINGUNO' };
            this.MESH_MOTIVO = { VALUE: 'NINGUNO' };

            this.Marca = { VALUE: 'NINGUNO' };
            this.Modelo = { VALUE: 'NINGUNO' };
            this.Cantidad = '';
            this.NroPedido = '';
            this.FechaEntrega = '';
            this.ComboDepartamento = 'SELECCIONAR';
            this.ComboProvincia = 'SELECCIONAR';
            this.ComboDistrito = 'SELECCIONAR';
            this.DireccionEntrega = '';

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
            // Revisar función calcular()
            //    this.Lista70 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 70); this.Lista71 = [];
            this.Lista80 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 80); this.Lista81 = [];
            this.Lista85 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 85); this.Lista86 = [];
            this.Lista87 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 87); this.FC = { VALUE: 'NINGUNO' };
            this.Lista88 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 88);
            this.Lista100 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 100); this.Lista101 = [];
            this.Lista105 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 105);

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
                case 42: { this.Lista42 = lista; this.MOTIVO_RESPONSABILIDAD = { VALUE: 'NINGUNO' }; this.Lista43 = []; break; }
                case 43: { this.Lista43 = lista; this.SUB_MOTIVO_RESPONSABILIDAD = { VALUE: 'NINGUNO' }; break; }


                case 51: { this.Lista51 = lista; this.MOTIVO_1 = { VALUE: 'NINGUNO' }; this.Lista52 = []; this.Lista53 = []; this.Lista54 = []; this.Lista55 = []; break; }
                case 52: { this.Lista52 = lista; this.MOTIVO_2 = { VALUE: 'NINGUNO' }; this.Lista53 = []; this.Lista54 = []; this.Lista55 = []; break; }
                case 53: { this.Lista53 = lista; this.MOTIVO_3 = { VALUE: 'NINGUNO' }; this.Lista54 = []; this.Lista55 = []; break; }
                case 54: { this.Lista54 = lista; this.MOTIVO_4 = { VALUE: 'NINGUNO' }; this.Lista55 = []; break; }
                case 55: { this.Lista55 = lista; this.MOTIVO_5 = { VALUE: 'NINGUNO' }; break; }

                case 62: { this.Lista62 = lista; this.ACEPTA_UPGRADE = { VALUE: 'NINGUNO' }; this.Lista63 = []; break; }
                case 63: { this.Lista63 = lista; this.MOTIVO_NO_UPGRADE = { VALUE: 'NINGUNO' }; break; }

                case 71: { this.Lista71 = lista; this.MOTIVO_FULL_CLARO = { VALUE: 'NINGUNO' }; break; }
                case 81: { this.Lista81 = lista; this.CONTACTABILIDAD_DETALLE = { VALUE: 'NINGUNO' }; break; }
                case 86: { this.Lista86 = lista; this.MESH_MOTIVO = { VALUE: 'NINGUNO' }; break; }
                case 101: { this.Lista101 = lista; this.Modelo = { VALUE: 'NINGUNO' }; break; }
            }

            if (item.ACCIONES.length > 3) {
                this.mostrarModal({ msg: item.ACCIONES, modal: 'formularioError' })

            }
        },
        calificar: function (item) {
            this.SPEECH = '';
            this.FECHA_DIA = ''
            this.FECHA_HORA = 'SELECCIONAR';

            this.CONFORMIDAD = item.OBSERVACION;
            this.SPEECH = item.SPEECH;
            let lista = [];
            if (this.TIPO_GESTION.VALUE == 'PF_BASE_CHURN_FTTH_DYN') {
                lista = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 50 && producto.OBSERVACION == item.OBSERVACION && producto.SPEECH == 'PF_BASE_CHURN_FTTH_DYN');
            } else {
                lista = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 50 && producto.OBSERVACION == item.OBSERVACION && producto.SPEECH != 'PF_BASE_CHURN_FTTH_DYN');
            } 
            //alert(JSON.stringify(lista));
            // this.Lista50 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 50 && producto.OBSERVACION == item.OBSERVACION);
            this.Lista50 = lista;
            this.Lista51 = []; this.MOTIVO_1 = { VALUE: 'NINGUNO' }; this.Lista52 = []; this.Lista53 = []; this.Lista54 = []; this.Lista55 = [];
            //this.Lista51 = []; this.Lista52 = []; this.Lista53 = []; this.Lista54 = []; this.Lista55 = [];
            this.calcular();
        },
        calcular: function () {
            this.SPEECH = '';

            if (this.RESULTADO.VALUE == 'POR CONFIRMAR') {
                this.Lista70 = []; this.Lista71 = []; this.Lista70.push({ VALUE: 'PENDIENTE POR CONFIRMAR' }); this.FULL_CLARO.VALUE = 'PENDIENTE POR CONFIRMAR';
            } else { this.Lista70 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 70); this.Lista71 = []; }

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

        cargarMotivo: function () { 
            

            
        },
        activarPreventiva: function () {   ///////////////////////////////////////////////////////////////
            this.ListaSolucion = [];
            this.limpiarFormulario();
            this.iniciar();
            this.cargarControles();
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
        iniciar: function () {
            axios.post(this.SERVER_URL + '/api/Claro/AdministrarPreventiva', {
                USUARIO: this.USUARIO,
                ID: this.ID,
                TIPO: 1
            }).then(response => {
                if (response.data.ID > 0) {
                    this.ID = response.data.ID;
                    this.coneccion({ CONTENIDO: 'PREV. IN | Gestion', ID: this.ID });
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        },
        guardar: function () {
            let msg = 'Verificar los siguientes campos: ';
             
            if (this.CONTACTABILIDAD.VALUE != 'SELECCIONAR' && this.SN.length > 15 && this.TIPO_GESTION.VALUE != 'SELECCIONAR') {
                //this.TIPO_GESTION = { VALUE: 'PF_MODELO_CHURN_DYN' };
                if (this.CONTACTABILIDAD.VALUE == 'CONTACTO EFECTIVO' && this.CONTACTABILIDAD_DETALLE.VALUE == 'CALIFICA') {
                    if (this.TIPO_GESTION.VALUE != 'SELECCIONAR' && this.CALIFICACION.VALUE != 'SELECCIONAR' && this.RESULTADO.VALUE != 'SELECCIONAR' && this.FULL_CLARO.VALUE != 'SELECCIONAR'  && this.RESPONSABILIDAD.VALUE != 'SELECCIONAR' && this.MOTIVO_RESPONSABILIDAD.VALUE != 'SELECCIONAR' && this.SUB_MOTIVO_RESPONSABILIDAD.VALUE != 'SELECCIONAR') {
                        msg = this.TIPO_GESTION.VALUE == 'NINGUNO' ? msg + " Tipo gestión" : msg;
                        msg = this.CUSTOMER_ID.length < 5 ? msg + " Customer ID" : msg;
                        msg = this.MOTIVO.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        msg = this.MOTIVO_1.VALUE == 'NINGUNO' ? msg + " Motivo" : msg; 
                        if (this.Lista52.length > 0) {
                            msg = this.MOTIVO_2.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        }
                        if (this.Lista53.length > 0) {
                            msg = this.MOTIVO_3.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        }
                        if (this.Lista54.length > 0) {
                            msg = this.MOTIVO_4.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        }
                        if (this.Lista55.length > 0) {
                            msg = this.MOTIVO_5.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        }
                        msg = this.VELOCIDAD_CONTRADA == 'SELECCIONAR' ? msg + " Velocidad contrada" : msg;
                        msg = this.TEST_VELOCIDAD == 'SELECCIONAR' ? msg + " Cuanto marca Test de velocidad" : msg;
                        msg = this.EQUIPO_CORRECTO == 'SELECCIONAR' ? msg + " Equipo correcto" : msg;
                        msg = this.ListaSolucion.length < 2 ? msg + " Solución y Arma" : msg;




                        if (this.MOTIVO_2.VALUE == 'ALINEADO EN INCOGNITO / SIAC / NO SATURADO / EQUIPO CORRECTO / USO ADECUADO') {
                            msg = this.PLAN_ACTUALIZADO == 'SELECCIONAR' ? msg + " PLAN_ACTUALIZADO" : msg;
                        }
                        if (this.Lista62.length > 0) {
                            msg = this.ACEPTA_UPGRADE.VALUE == 'NINGUNO' ? msg + " ACEPTA_UPGRADE" : msg;
                        }
                        if (this.Lista63.length > 0) {
                            msg = this.MOTIVO_NO_UPGRADE.VALUE == 'NINGUNO' ? msg + " MOTIVO_NO_UPGRADE" : msg;
                        }
                         
                        msg = this.RESULTADO.VALUE == 'SELECCIONAR' ? msg + " RESULTADO" : msg;

                        if (this.RESULTADO.VALUE == 'EN PROCESO' || this.RESULTADO.VALUE == 'POR CONFIRMAR') {
                            msg = this.TELEFONO.length < 5 ? msg + " Teléfono" : msg;
                            msg = (this.FECHA_HORA == 'SELECCIONAR' || this.FECHA_DIA == '') ? msg + " Fecha no valida" : msg;

                            this.FECHA_AGENDA = this.FECHA_DIA + ' ' + this.FECHA_HORA;
                        } else {
                            this.FECHA_AGENDA = '2021-01-01' + ' 00:00';
                        }

                        if (msg.length > 34) {
                            this.mostrarToast({ toast: 'danger', msg: msg });
                            return 0;
                        } else {
                            this.generarPlantilla();

                            axios.post(this.SERVER_URL + '/api/Claro/AdministrarPreventiva', {
                                ID: this.ID,
                                SN: this.SN,
                                CONTACTABILIDAD: this.CONTACTABILIDAD.VALUE,
                                CONTACTABILIDAD_DETALLE: this.CONTACTABILIDAD_DETALLE.VALUE,
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
                                MOTIVO_RESPONSABILIDAD: this.MOTIVO_RESPONSABILIDAD.VALUE,
                                SUB_MOTIVO_RESPONSABILIDAD: this.SUB_MOTIVO_RESPONSABILIDAD.VALUE,
                                FULL_CLARO: this.FULL_CLARO.VALUE,
                                MOTIVO_FULL_CLARO: this.MOTIVO_FULL_CLARO.VALUE,
                                MOTIVO_FINAL: this.MOTIVO_RAIZ.VALUE,

                                OBSERVACION: this.OBSERVACION,
                                PLANTILLA: this.PLANTILLA,
                                FECHA_AGENDA: this.FECHA_AGENDA,
                                USUARIO: this.USUARIO,
                                TIPO: 2

                            }).then(response => {
                                if (response.data.ID > 0) {
                                    //alert(this.RESULTADO.VALUE); 
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
                                                this.mostrarToast({ toast: 'success', msg: 'Enviando caso al backoffice' }); 
                                                this.coneccion({ CONTENIDO: 'DISPONIBLE', ID: this.ID });
                                                this.activarPreventiva();
                                            } 
                                        }).catch(e => {
                                        });
                                    } else {
                                        this.coneccion({ CONTENIDO: 'DISPONIBLE', ID: this.ID });
                                        this.activarPreventiva();
                                        this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                                    }
                                } else {  
                                    this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                                }
                            }).catch(e => {
                                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                            });
                        }
                    }

                } else {
                    msg = this.TIPO_GESTION.VALUE == 'SELECCIONAR' ? msg + " Tipo gestión" : msg;
                    if (this.CONTACTABILIDAD.VALUE == 'CONTACTO EFECTIVO' || this.CONTACTABILIDAD.VALUE == 'CONTACTO NO EFECTIVO') {
                        msg = this.CONTACTABILIDAD_DETALLE.VALUE == 'NINGUNO' ? msg + "CONTACTABILIDAD_DETALLE" : msg;
                    }
                    if (msg.length > 34) {
                        this.mostrarToast({ toast: 'danger', msg: msg });
                        return 0;
                    } else {

                        this.generarPlantilla();
                        axios.post(this.SERVER_URL + '/api/Claro/AdministrarPreventiva', {
                            ID: this.ID,
                            SN: this.SN,
                            CONTACTABILIDAD: this.CONTACTABILIDAD.VALUE,
                            CONTACTABILIDAD_DETALLE: this.CONTACTABILIDAD_DETALLE.VALUE,
                            TIPO_GESTION: this.TIPO_GESTION.VALUE,
                            CUSTOMER_ID: this.CUSTOMER_ID,
                            OBSERVACION: this.OBSERVACION,
                            PLANTILLA: this.PLANTILLA,
                            USUARIO: this.USUARIO,
                            TIPO: 2
                        }).then(response => {
                            if (response.data.ID > 0) {
                                this.coneccion({ CONTENIDO: 'DISPONIBLE', ID: this.ID });
                                this.activarPreventiva();
                            } else {
                                this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                            }
                        }).catch(e => {
                            this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                        });
                    }
                }
            }

        },

        guardarBaseChurn: function () {
            let msg = 'Verificar los siguientes campos: ';
            this.TIPO_GESTION = { VALUE: 'PF_MODELO_CHURN_DYN' }; 
            if (this.CONTACTABILIDAD.VALUE != 'SELECCIONAR' && this.CONTACTABILIDAD_DETALLE.VALUE != 'SELECCIONAR' && this.SN.length > 15) {
                 
                
                if (this.CONTACTABILIDAD.VALUE == 'CONTACTO EFECTIVO' && this.CONTACTABILIDAD_DETALLE.VALUE == 'CALIFICA') {
                    if (this.TIPO_GESTION.VALUE != 'SELECCIONAR' && this.CALIFICACION.VALUE != 'SELECCIONAR' && this.RESULTADO.VALUE != 'SELECCIONAR' && this.FULL_CLARO.VALUE != 'SELECCIONAR' && this.RESPONSABILIDAD.VALUE != 'SELECCIONAR' && this.MOTIVO_RESPONSABILIDAD.VALUE != 'SELECCIONAR' && this.SUB_MOTIVO_RESPONSABILIDAD.VALUE != 'SELECCIONAR') {
                        msg = this.TIPO_GESTION.VALUE == 'NINGUNO' ? msg + " Tipo gestión" : msg;
                        msg = this.CUSTOMER_ID.length < 5 ? msg + " Customer ID" : msg;
                        msg = this.MOTIVO.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        msg = this.MOTIVO_1.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        if (this.Lista52.length > 0) {
                            msg = this.MOTIVO_2.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        }
                        if (this.Lista53.length > 0) {
                            msg = this.MOTIVO_3.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        }
                        if (this.Lista54.length > 0) {
                            msg = this.MOTIVO_4.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        }
                        if (this.Lista55.length > 0) {
                            msg = this.MOTIVO_5.VALUE == 'NINGUNO' ? msg + " Motivo" : msg;
                        }
                        msg = this.VELOCIDAD_CONTRADA == 'SELECCIONAR' ? msg + " Velocidad contrada" : msg;
                        msg = this.TEST_VELOCIDAD == 'SELECCIONAR' ? msg + " Cuanto marca Test de velocidad" : msg;
                        msg = this.EQUIPO_CORRECTO == 'SELECCIONAR' ? msg + " Equipo correcto" : msg;
                        msg = this.ListaSolucion.length < 2 ? msg + " Solución y Arma" : msg;



                        if (this.MOTIVO_2.VALUE == 'ALINEADO EN INCOGNITO / SIAC / NO SATURADO / EQUIPO CORRECTO / USO ADECUADO') {
                            msg = this.PLAN_ACTUALIZADO == 'SELECCIONAR' ? msg + " PLAN_ACTUALIZADO" : msg;
                        }
                        if (this.Lista62.length > 0) {
                            msg = this.ACEPTA_UPGRADE.VALUE == 'NINGUNO' ? msg + " ACEPTA_UPGRADE" : msg;
                        }
                        if (this.Lista63.length > 0) {
                            msg = this.MOTIVO_NO_UPGRADE.VALUE == 'NINGUNO' ? msg + " MOTIVO_NO_UPGRADE" : msg;
                        }

                        if (this.RESULTADO.VALUE == 'EN PROCESO' || this.RESULTADO.VALUE == 'POR CONFIRMAR') {
                            msg = this.TELEFONO.length < 5 ? msg + " Teléfono" : msg;
                            msg = (this.FECHA_HORA == 'SELECCIONAR' || this.FECHA_DIA == '') ? msg + " Fecha no valida" : msg;

                            this.FECHA_AGENDA = this.FECHA_DIA + ' ' + this.FECHA_HORA;
                        } else {
                            this.FECHA_AGENDA = '2021-01-01' + ' 00:00';
                        }

                        if (msg.length > 34) {
                            this.mostrarToast({ toast: 'danger', msg: msg });
                            return 0;
                        } else {
                            this.generarPlantilla();

                            axios.post(this.SERVER_URL + '/api/Claro/AdministrarPreventiva', {
                                ID: this.ID,
                                SN: this.SN,
                                CONTACTABILIDAD: this.CONTACTABILIDAD.VALUE,
                                CONTACTABILIDAD_DETALLE: this.CONTACTABILIDAD_DETALLE.VALUE,
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
                                MOTIVO_RESPONSABILIDAD: this.MOTIVO_RESPONSABILIDAD.VALUE,
                                SUB_MOTIVO_RESPONSABILIDAD: this.SUB_MOTIVO_RESPONSABILIDAD.VALUE,
                                FULL_CLARO: this.FULL_CLARO.VALUE,
                                MOTIVO_FULL_CLARO: this.MOTIVO_FULL_CLARO.VALUE,
                                MOTIVO_FINAL: this.MOTIVO_RAIZ.VALUE,

                                OBSERVACION: this.OBSERVACION,
                                PLANTILLA: this.PLANTILLA,
                                FECHA_AGENDA: this.FECHA_AGENDA,
                                USUARIO: this.USUARIO,
                                TIPO: 2

                            }).then(response => {
                                //alert(this.RESULTADO.VALUE); 
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
                                            this.mostrarToast({ toast: 'success', msg: 'Enviando caso al backoffice' });
                                            this.coneccion({ CONTENIDO: 'DISPONIBLE', ID: this.ID });
                                            this.activarPreventiva();
                                        }
                                    }).catch(e => {
                                    });
                                } else {
                                    this.coneccion({ CONTENIDO: 'DISPONIBLE', ID: this.ID });
                                    this.activarPreventiva();
                                    this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                                }
                            }).catch(e => {
                                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                            });
                        }
                    }

                } else {
                    this.generarPlantilla();
                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarPreventiva', {
                        ID: this.ID,
                        SN: this.SN,
                        CONTACTABILIDAD: this.CONTACTABILIDAD.VALUE,
                        CONTACTABILIDAD_DETALLE: this.CONTACTABILIDAD_DETALLE.VALUE,
                        TIPO_GESTION: this.TIPO_GESTION.VALUE,
                        CUSTOMER_ID: this.CUSTOMER_ID,
                        OBSERVACION: this.OBSERVACION,
                        PLANTILLA: this.PLANTILLA,
                        USUARIO: this.USUARIO,
                        TIPO: 2
                    }).then(response => {
                        if (response.data.ID > 0) {
                            this.coneccion({ CONTENIDO: 'DISPONIBLE', ID: this.ID });
                            this.activarPreventiva();
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
                if (`${this.ListaSolucion[item].ID_GRUPO}` == 1) { solucion = solucion + `${this.ListaSolucion[item].OFRECIMIENTO}` + ' - '; }
                else { arma = arma + `${this.ListaSolucion[item].OFRECIMIENTO}` + ' - '; }
            }
            solucion = solucion.slice(0, -2); arma = arma.slice(0, -2);

            this.PLANTILLA = " | Contactabilidad: " + this.CONTACTABILIDAD.VALUE + " - " + this.CONTACTABILIDAD_DETALLE.VALUE + " | SIAC" + " | SN: " + this.SN + " | Contacto: " + this.CONTACTO.VALUE + " | Customer ID: " + this.CUSTOMER_ID + " | Teléfono: " + this.TELEFONO + " | Tipo gestión: " + this.TIPO_GESTION.VALUE + " | Calificación: " + this.CALIFICACION.VALUE + " | Conformidad: " + this.CONFORMIDAD +
                " | Motivo: " + this.MOTIVO.VALUE + " | Motivo 1: " + this.MOTIVO_1.VALUE + " | Motivo 2: " + this.MOTIVO_2.VALUE + " | Motivo 3: " + this.MOTIVO_3.VALUE + " | Motivo 4: " + this.MOTIVO_4.VALUE + " | Motivo 5: " + this.MOTIVO_5.VALUE +
                " | Velocidad: " + this.VELOCIDAD.VALUE + " | Rango: " + this.RANGO.VALUE + " | Test velocidad: " + this.RANGO_VELOCIDAD + " | Cant. equipos conectados: " + this.CANTIDAD_EQUIPOS.VALUE +
                " | Plan actualizado: " + this.PLAN_ACTUALIZADO.VALUE + " | Acepta Upgrade: " + this.ACEPTA_UPGRADE.VALUE + " | Motivo no Upgrade: " + this.MOTIVO_NO_UPGRADE.VALUE +
                " | Solución: " + solucion + " | Arma: " + arma +
                " | Resultado: " + this.RESULTADO.VALUE + " | Resultado final: " + this.RESULTADO_FINAL + " | Responsabilidad: " + this.RESPONSABILIDAD.VALUE + " | Responsabilidad Motivo: " + this.MOTIVO_RESPONSABILIDAD.VALUE + " | Responsabilidad Sub Motivo: " + this.SUB_MOTIVO_RESPONSABILIDAD.VALUE +
                " | Full Claro: " + this.FULL_CLARO.VALUE + " | Motivo Full Claro: " + this.MOTIVO_FULL_CLARO.VALUE + " | Motivo Full Claro POP UP: " + this.MOTIVO_RAIZ.VALUE +
                " | Observación: " + this.OBSERVACION + " | Fecha agenda: " + this.FECHA_AGENDA + " | Usuario: " + this.USUARIO + "-" + this.APELLIDOS + " " + this.NOMBRES;
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

        validarFullClaro: function (item) {
            if (item.VALUE == 'NO ES FULL CLARO') {
                this.pantalla({ PANTALLA: 'formularioFull' });
            }
        },

        guardarFullClaro: function () {
            this.$bvModal.hide('formularioFull');
        },

        abrirOfrecimientos: function (item) {
            this.Lista21 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 21 && producto.OBSERVACION == item.Ofrecimiento);
            this.OFRECIMIENTO = { VALUE: 'NINGUNO' };
            this.GESTION = { VALUE: 'NINGUNO' };
            this.tipoDescuento = '';
            this.VARIABLE = '0';

            this.MensajeSistema = item.Ofrecimiento;
            this.mostrarModal({ modal: 'formularioOfrecimiento', msg: item.Ofrecimiento });
        },

        registrarOfrecimiento: function () {
            if (this.OFRECIMIENTO.VALUE != 'NINGUNO') {

                let msg = "Verificar los siguientes campos: ";
                let tipoDescuento = ''; let meses = ''; let ubigeo = '';
                let texto = '| ' + this.MensajeSistema + ': ' + this.OFRECIMIENTO.VALUE + ' - ' + this.GESTION.VALUE + ' ' + this.VARIABLE + ' | ' + ' Acepta MESH: ' + this.MESH_RESULTADO.VALUE + '-' + this.MESH_MOTIVO.VALUE;


                if (this.OFRECIMIENTO.SPEECH == 'SI' && this.OFRECIMIENTO.VALUE != 'REPETIDOR MESH') {
                    msg = this.GESTION.VALUE == 'SELECCIONAR' ? msg + " Gestion" : msg;
                    if (this.GESTION.SPEECH == 'SI') { msg = this.VARIABLE.length < 8 ? msg + " Valor " + this.GESTION.VALUE : msg; }
                }
                if (this.OFRECIMIENTO.VALUE == 'REPETIDOR MESH') {
                    msg = this.MESH_RESULTADO.VALUE == 'NINGUNO' ? msg + " Resultado MESH" : msg;
                    msg = this.MESH_MOTIVO.VALUE == 'NINGUNO' ? msg + " Motivo MESH" : msg;
                    if (this.MESH_RESULTADO.VALUE == 'ACEPTA') {
                        msg = this.Marca.VALUE == 'NINGUNO' ? msg + " Repetidor Mesh Marca" : msg;
                        msg = this.Modelo.VALUE == 'NINGUNO' ? msg + " Repetidor Mesh Modelo" : msg;
                        msg = this.Cantidad.length < 1 ? msg + " Repetidor Mesh Cantidad" : msg;

                        texto = texto + " | Marca: " + this.Marca.VALUE;
                        texto = texto + " | Modelo: " + this.Modelo.VALUE;
                        texto = texto + " | Cantidad: " + this.Cantidad;
                        if (this.MESH_MOTIVO.VALUE == 'SI GENERA VENTA') {
                            msg = this.NroPedido.length < 8 ? msg + " Repetidor Mesh número pedido" : msg;
                            msg = this.FechaEntrega.length < 8 ? msg + " Repetidor Mesh fecha entrega" : msg;
                            texto = texto + " | Nro pedido: " + this.NroPedido;
                            texto = texto + " | Fecha entrega: " + this.FechaEntrega;

                            tipoDescuento = this.NroPedido;
                            meses = this.FechaEntrega;
                        } else {
                            msg = this.DireccionEntrega.length < 5 ? msg + " Repetidor Mesh dirección entrega" : msg;
                            msg = this.ComboDepartamento == 'SELECCIONAR' ? msg + " Departamento" : msg;
                            msg = this.ComboProvincia == 'SELECCIONAR' ? msg + " Provincia" : msg;
                            msg = this.ComboDistrito == 'SELECCIONAR' ? msg + " Distrito" : msg;
                            texto = texto + " | Dirección entrega: " + this.DireccionEntrega;
                            texto = texto + " | Ubigeo: " + this.ComboDepartamento.VALUE + " - " + this.ComboProvincia.VALUE + " - " + this.ComboDistrito.VALUE;
                            ubigeo = "Departamento: " + this.ComboDepartamento.VALUE + " | Provincia: " + this.ComboProvincia.VALUE + " | Distrito: " + this.ComboDistrito.VALUE;
                            meses = this.DireccionEntrega;
                        }
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
                } else if (this.OFRECIMIENTO.VALUE == 'NO APLICA') {
                    msg = this.Periodo.VALUE == 'SELECCIONAR' ? msg + "  Motivo no aplica" : msg;
                    texto = texto + " | Motivo: " + this.Periodo.VALUE;

                    meses = this.Periodo.VALUE;
                }

                if (msg.length < 35) {
                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarOfrecimiento', {
                        ID_SOURCE: this.ID,
                        OFRECIMIENTO: this.OFRECIMIENTO.VALUE,
                        GESTION: texto,
                        OBSERVACION: ubigeo, //this.OBSERVACION,
                        TIPO_DESCUENTO: tipoDescuento,
                        MESES: meses,
                        MOTIVO: this.MESH_RESULTADO.VALUE,
                        MOTIVO_II: this.MESH_MOTIVO.VALUE,
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
        
        agenda() {
            this.Lista20 = [];
            axios.post(this.SERVER_URL + '/api/Claro/ListarAgendamientos', {
                ID: this.ID,
                CONTENIDO: this.FECHA_DIA,
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