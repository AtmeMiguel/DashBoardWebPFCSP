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
        ID_LIST: 0,
        CUSTOMER_ID: '0',
        ESTADO: '',
        MOTIVO: '',
        SOT: '',
        SOT_NA: false,
        CASO: '',
        CASO_NA: false,
        OBSERVACION: '',
        PLANTILLA: '',
        MENSAJE: '',
        show: false,
        ListaOfrecimiento: [],
        ListaPrincipal: [],
        ListaSolucion: [],
        ListaGeneral: [],
        fieldsBO: ['ID', 'OFRECIMIENTO', 'GESTION', 'ESTADO', 'MOTIVO', 'FECHA'],
    },
    methods: {
        mostrarModal: function (form) {
            this.MensajeSistema = form.msg;
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

        limpiarFormulario: function () {
            this.ID_SOLUCION = 0;
            this.CUSTOMER_ID = '';
            this.ESTADO = '';
            this.MOTIVO = '';
            this.SOT = '';
            this.SOT_NA = false;
            this.CASO_NA = false;
            this.CASO = '';
            this.SPEECH = '';
            this.OBSERVACION = '';
            this.ListaSolucion = [];
            this.ListaPrincipal = [];
            this.ListaOfrecimiento = [];
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
                }
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        },

        iniciar: function (item) {
            this.limpiarFormulario();
            axios.post(this.SERVER_URL + '/api/Formulario/MantenimientoFormulario', {
                ID: 0,
                ID_USUARIO: this.ID_USUARIO,
                ID_SEDE: this.ID_SEDE,
                TIPO: 72,
            }).then(response => {
                if (response.data.ID > 0) {
                    this.ID = response.data.ID;
                    this.ID_LIST = response.data.RESULTADO;
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
                            this.coneccion({ CONTENIDO: 'RET. BO PT | Gestion', ID: this.ID });
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
                    this.ESTADO = '';
                    this.MOTIVO = '';
                    this.OBSERVACION = '';
                    this.SOT = '';
                    this.CASO = '';
                    this.SOT_NA = false;
                    this.CASO_NA = false;
                    this.OFRECIMIENTO = item.OFRECIMIENTO;
                    this.GESTION = item.GESTION;
                }
            }).catch(e => {
                this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' });
            });
        },

        guardar: function () {
            let msg = 'Verificar los siguientes campos: ';
            if (this.ESTADO != '') {
                if (this.SOT_NA == false) { msg = this.SOT.length < 8 ? msg + " SOT" : msg; } else { this.SOT = '00000000' }
                if (this.CASO_NA == false) { msg = this.CASO.length < 8 ? msg + " CASO" : msg; } else { this.CASO = '00000000' }
                this.OBSERVACION = this.OBSERVACION + '|SOT: ' + this.SOT + '|CASO:' + this.CASO;
                if (msg.length > 34) {
                    this.mostrarToast({ toast: 'danger', msg: msg });
                } else {
                    axios.post(this.SERVER_URL + '/api/Claro/AdministrarOfrecimiento', {
                        ID: this.ID_SOLUCION,
                        ID_SOURCE: this.ID,   //ID_SOURCE
                        ESTADO: this.ESTADO,
                        MOTIVO: this.MOTIVO,
                        MOTIVO_II: '',

                        OBSERVACION: this.OBSERVACION,
                        USUARIO: this.USUARIO,

                        TIPO: 6,
                    }).then(response => {
                        if (response.data.ID > 0) {
                            this.ListaOfrecimiento = this.ListaOfrecimiento.filter(i => i.ID != this.ID_SOLUCION);
                            this.ListaOfrecimiento.push({ ID: this.ID_SOLUCION, OFRECIMIENTO: this.OFRECIMIENTO, GESTION: this.GESTION, ESTADO: this.ESTADO, MOTIVO: this.MOTIVO, FECHA: 'AHORA', OBSERVACION: this.OBSERVACION })
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
        },
        salir: function () {
            let lista = this.ListaOfrecimiento.filter(i => i.ESTADO == 'PENDIENTE');
            if (lista.length > 0) {
                this.mostrarToast({ toast: 'warning', msg: 'Verificar ofrecimientos ...' });
            } else {
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
                        axios.post(this.SERVER_URL + '/api/Claro/AdministrarRetenciones', {
                            USUARIO: this.USUARIO,
                            ID: this.ID,
                            TIPO: 3
                        }).then(response => {
                            if (response.data.ID > 0) {
                                this.coneccion({ CONTENIDO: 'RET. BO PT', ID: this.ID });
                                this.ID_LIST = 0;
                                this.ID = 0;
                            }
                        }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });

                    }
                }).catch(e => { });
            }
        }

    }
})
app.listarGraficoGeneral();

