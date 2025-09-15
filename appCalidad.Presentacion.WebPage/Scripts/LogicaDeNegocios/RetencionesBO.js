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
        idServicio: 1,
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
        ID_SOLUCION: 0,
        CUSTOMER_ID: '0',
        ESTADO: '',
        MOTIVO: '',
        SN_BO: '',
        FECHA: '',
        HORA: '',
        CAMPO: 'AGENDADO',
        CONTENIDO: sessionStorage.getItem('USUARIO'),
        OFRECIMIENTO: '',
        GESTION: '',
        OBSERVACION: '',
        PLANTILLA: '',
        categoryIdFilter: '',
        min: minDate,
        max: maxDate,
        MENSAJE: '',
        show: false,
        Lista1: [],
        Lista8: [],
        Lista9:[],
        ListaBandeja: [],
        categories: [],
        ListaOfrecimiento: [],
        ListaPrincipal: [],
        ListaSolucion: [],
        fields: ['ID', 'FECHA_AGENDA', 'FECHA_REGISTRO', 'CUSTOMER_ID', 'OFRECIMIENTO', 'MOTIVO', 'DNI_BO','SUPERVISOR', 'AGENTE'],
        fieldsBO: ['ID', 'OFRECIMIENTO', 'GESTION', 'ESTADO', 'MOTIVO', 'FECHA'],
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
            this.CUSTOMER_ID = '';

            this.ESTADO = { VALUE: 'NINGUNO', ID_CONTROL: 0 };
            this.MOTIVO = { VALUE: 'NINGUNO', ID_CONTROL: 0 };
            this.SN_BO = '';
            this.FECHA = '';
            this.HORA = { VALUE: 'NINGUNO', ID_CONTROL: 0 };
            this.OBSERVACION = '';

            this.ListaSolucion = [];
        },

        cargarDropdow: function (item) {         //alert(JSON.stringify(lista));
            let idControl = item.ID_CONTROL + 1;
            let lista = [];
            lista = this.ListaPrincipal.filter(producto => producto.ID_DEPENDENCIA == item.ID);
            switch (idControl) {
                case 9: {
                    this.Lista9 = lista; this.MOTIVO = {VALUE: 'NINGUNO'}; this.SN_BO = ''; this.FECHA = ''; this.HORA = { VALUE: 'NINGUNO' }; break; }
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
                    this.mostrarToast({ toast: 'success', msg: 'Mensaje confirmado' });
                }
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        },
         
        iniciar: function (item) { 
            this.PLANTILLA = [];
            let plantilla = item.PLANTILLA;
            let separado = plantilla.split("|");
            for (var f in separado) {
                this.PLANTILLA.push({ name: separado[f] });
            }
            this.ID = item.ID;
            this.MOTIVO = item.MOTIVO;
            axios.post(this.SERVER_URL + '/api/Claro/ListarOfrecimiento', {
                ID: item.ID,
                TIPO: 4
            }).then(response => {
                if (response.data.length > 0) {
                    this.ListaOfrecimiento = response.data;
                    this.ListaBandeja = [];
                    this.coneccion({ CONTENIDO: 'RET. BO | Gestion', ID: this.ID });
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
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
                     
                    this.Lista8 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 8 && producto.DEPENDENCIA == item.OFRECIMIENTO);
                    this.Lista9 = []; 
                    this.Lista11 = this.ListaPrincipal.filter(producto => producto.ID_CONTROL == 11);

                    this.ESTADO = { VALUE: 'NINGUNO' }; this.MOTIVO = { VALUE: 'NINGUNO' }; this.HORA = { VALUE: 'NIGUNO' };
                    this.OBSERVACION = '';
                    this.OFRECIMIENTO = item.OFRECIMIENTO;
                    this.GESTION = item.GESTION;
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        },
        guardar: function () {
            let msg = 'Verificar los siguientes campos: ';
            if (this.ESTADO.VALUE != 'NINGUNO' && this.MOTIVO.VALUE != 'NINGUNO') {
                if (this.ESTADO.VALUE == 'Atendido' && this.ESTADO.VALUE == 'No Atendido') {
                    msg = this.SN_BO.length < 16 ? msg + " SN" : msg;
                    this.FECHA = '2021-01-01';
                    this.HORA = { VALUE: ' 00:00'}
                } else if (this.ESTADO.VALUE == 'Seguimiento') {
                    msg = this.FECHA == '' ? msg + " Fecha" : msg;
                    msg = this.HORA.VALUE == 'NINGUNO' ? msg + " Hora" : msg;
                }

                if (msg.length > 34) {
                    this.mostrarToast({ toast: 'danger', msg: msg });
                } else {
                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarOfrecimiento', {
                        ID: this.ID_SOLUCION,
                        ID_SOURCE: this.ID,   //ID_SOURCE
                        ESTADO: this.ESTADO.VALUE,
                        MOTIVO: this.MOTIVO.VALUE,
                        MOTIVO_II: '',

                        OBSERVACION: this.OBSERVACION,
                        USUARIO: this.USUARIO,

                        TIPO: 6,
                    }).then(response => {
                        if (response.data.ID > 0) {
                            this.ListaOfrecimiento = this.ListaOfrecimiento.filter(i => i.ID != this.ID_SOLUCION);
                            this.ListaOfrecimiento.push({ ID: this.ID_SOLUCION, OFRECIMIENTO: this.OFRECIMIENTO, GESTION: this.GESTION, ESTADO: this.ESTADO.VALUE, MOTIVO: this.MOTIVO.VALUE, FECHA: 'AHORA', OBSERVACION: this.OBSERVACION })
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
        cargarBandeja: function () {
            if (this.CAMPO.length > 0 && this.CONTENIDO.length > 5) {
                this.show = true;
                axios.post(this.SERVER_URL + '/api/Claro/ListarBandejaRetenciones', {
                    CONTENIDO: this.CONTENIDO,
                    CAMPO: this.CAMPO,
                }).then(response => {
                    if (response.data.length >= 0) {
                        this.show = false;
                        this.ListaBandeja = response.data;
                        this.ListaBandeja_ = response.data;
                        this.categories = [];
                        const map = new Map();
                        for (const item of this.ListaBandeja) {
                            if (!map.has(item.SUPERVISOR)) {
                                map.set(item.SUPERVISOR, true);
                                this.categories.push({ text: item.SUPERVISOR });
                            }
                        }
                    }
                }).catch(e => {
                    this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
                });
            }
        },
        cargarOpciones: function () {
            axios.post(this.SERVER_URL + '/api/Opciones/ListarOpcionesCRM', {
                ID_GRUPO: this.idServicio,
                TIPO: 5,
            }).then(response => {
                if (response.data.length > 0) {
                    this.cargarBandeja();
                    
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        },
        buscar: function (item) {
            alert(item);
             if (item.length > 3) {
                 this.ListaBandeja = this.ListaBandeja_.filter(x => x.SUPERVISOR == item);
            } else {
                 this.ListaBandeja = this.ListaBandeja_;
            }
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
        salir: function (item) {
            alert(item);
            if (item == 0) {
                this.ListaBandeja = this.ListaBandeja_; this.ID = 0;
            } else if (item > 0) {
                this.ListaBandeja_ = this.ListaBandeja_.filter(i => i.ID != this.ID);
                this.ListaBandeja = this.ListaBandeja_; this.ID = 0;
            }
            
            //document.location.href = '../Claro/RetencionesBO';
        }
    }
})
app.cargarOpciones();
