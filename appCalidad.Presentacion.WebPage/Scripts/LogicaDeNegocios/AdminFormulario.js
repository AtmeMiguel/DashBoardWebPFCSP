
const now = new Date()
const today = new Date(now.getFullYear(), now.getMonth(), now.getDate())
const maxDate = new Date(today)
maxDate.setMonth(maxDate.getMonth())
var app = new Vue({
    el: '#app',
    data: {
        ID_USUARIO: sessionStorage.getItem('ID_USUARIO'),
        SERVER_URL: sessionStorage.getItem('SERVER_URL'),
        ID_SEDE: sessionStorage.getItem('ID_SEDE'),
        PAGINA: '@Title',

        ID: '',
        FORMULARIO: '',
        CAMPO_1: '',
        CAMPO_2: '',
        CAMPO_3: '',

        ID_ITEM: '',
        ITEM: '',
        CONTROL: '',
        NOMBRE: '',
        MODULO: '',
        OCULTAR: '',

        ID_ITEM_ITEM: '',
        ITEM_ITEM: '',
        VALOR: '',
        ID_DEPENDENCIA: 0,
        CHECK_DEPENDENCIA: 'True',

        NIVEL: '',
        SUB_NIVEL: '',

        MIN: '0',
        MAX: '0',
        ORDEN: '0',
        m:'',

        ListaNivel: [],
        ListaSubNivel: [],

        Lista: [],
        Lista_: [],
        ListaItem: [],
        ListacolumnasBD: [],
        ListaItemItem: [],
        ListaFormularioVsGrupo: [],
        Columnas: [
            'ID', 'TITULO', 'RESULTADO', 'PLANTILLA', 'FECHA', 'ACCIONES'
        ],
        ColumnasBD: [
            'ID', 'TITULO', 'ACCIONES'
        ],
        SITE: '',
        totalRows: 100,
        currentPage: 1,
        perPage: 100,
        pageOptions: [100, 200, 400, { value: 1000, text: "Show a lot" }],
        sortBy: '',
        sortDesc: false,
        sortDirection: 'asc',
        filter: '',
        filterOn: [],
        infoModal: {
            id: 'info-modal',
            title: '',
            content: ''
        }
    },
    mounted() {
        this.totalRows = this.Lista.length
    },
    methods: {
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
        off: function (item) {
            this.$bvModal.hide(item.PANTALLA);
        },
        resetInfoModal() {
            this.infoModal.title = '';
            this.infoModal.content = '';
        },
        onFiltered(filteredItems) {
            // Trigger pagination to update the number of buttons/pages due to filtering
            this.totalRows = filteredItems.length;
            this.currentPage = 1;
        },
        excel() {
            //document.location.href = this.SERVER_URL + 'Reportes/ClaroExcel/?ini=' + this.FECHA_INI + '&fin=' + this.FECHA_FIN + '&tipo=' + item.ID;
            document.location.href = this.SERVER_URL + 'Reportes/ReporteExcel/?ini=' + this.MIN + '&fin=' + this.MAX + '&id=' + this.ID + '&nombre=' + this.FORMULARIO  ;
        },
        buscar: function () {
            if (this.filter.length > 0) {
                let palabra = this.filter.toUpperCase();
                this.Lista = this.Lista_.filter(x => {
                    return x.TITULO.includes(palabra);
                });
            } else { this.Lista = this.Lista_; }
            this.currentPage = 1;
        },
        editar(item, index, button) {
            this.FORMULARIO = '';
            this.CAMPO_1 = '';
            this.CAMPO_2 = '';
            this.CAMPO_3 = '';
            if (item == 0) { this.ID = 0; } else {
                this.ID = item.ID;
                this.FORMULARIO = item.TITULO;
                this.CAMPO_1 = item.RESULTADO;
                this.CAMPO_3 = item.PLANTILLA;
                //this.CAMPO_3 = item.PLANTILLA;
                this.listarItem({ ID: this.ID, TITULO: this.FORMULARIO, CAMPO: this.CAMPO_1 }, 0, '');
                this.listarItemItem();
            }
            this.pantalla({ PANTALLA: 'editarFormulario' });
        },
        GuardarFormulario() {
            let mensaje = "Verificar los siguientes campos: ";
            mensaje = this.FORMULARIO.length < 5 ? mensaje + " TÍTULO" : mensaje;
            if (this.ID == 0) {
                mensaje = this.CAMPO_2.length < 10 ? mensaje + " TABLA LECTURA" : mensaje;
                mensaje = this.CAMPO_3.length < 10 ? mensaje + " TABLA" : mensaje;
            }
            if (mensaje.length < 34) {
                axios.post(this.SERVER_URL + '/api/Formulario/Mantenimiento', {
                    ID: this.ID,
                    TITULO: this.FORMULARIO,
                    CAMPO_1: this.CAMPO_1,
                    CAMPO_2: this.CAMPO_2,
                    CAMPO_3: this.CAMPO_3,

                    ID_USUARIO: this.ID_USUARIO,
                    ID_SEDE: this.ID_SEDE, 
                    TIPO: 2,
                }).then(response => {
                    if (response.data.ID > 0) {
                        this.ID = response.data.ID;
                        this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                    } else {
                        this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                    }
                }).catch(e => { this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error en la conexión, registro no guardado ...' }); });
            } else { this.mostrarToast({ toast: 'danger', msg: mensaje }); }
        },

        eliminar: function (item, index, button) {
            this.infoModal.title = `Row index: ${index}`
            this.infoModal.content = JSON.stringify(item, null, 2)
            this.ID = item.ID;
            this.$root.$emit('bv::show::modal', this.infoModal.id, button)
        },
        eliminarOk: function () {
            axios.post(this.SERVER_URL + '/api/Formulario/Mantenimiento', {
                ID: this.ID,
                TITULO: '',
                ID_USUARIO: this.ID_USUARIO,
                ID_SEDE: this.ID_SEDE,
                TIPO: 3,
            }).then(response => {
                if (response.data.ID > 0) {
                    this.Lista = this.Lista.filter(x => x.ID != this.ID);
                    this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                } else { this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' }); }
            }).catch(e => { this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error en la conexión, registro no guardado ...' }); });
        },

        registrarItem: function (item, index, button) {
            let cantidad = this.ListaItem.filter(x => x.TITULO == item.TITULO);
            if (cantidad.length == 0) {
                this.ID_ITEM = '0';
                this.ITEM = item.TITULO;
                this.NOMBRE = item.TITULO;
                this.CONTROL = 'Text';
                this.OCULTAR = '';
                this.off({ PANTALLA: 'columnasBD' });
            } else { this.mostrarToast({ toast: 'danger', msg: 'El campo ya esta registrado!' }); }
        },
        guardarItem: function () {
            let mensaje = "Verificar los siguientes campos: ";
            mensaje = this.CONTROL.length < 1 ? mensaje + " CONTROL" : mensaje;
            mensaje = this.NOMBRE.length < 1 ? mensaje + " NOMBRE" : mensaje;

            if (mensaje.length < 34) {
                axios.post(this.SERVER_URL + '/api/Formulario/Mantenimiento', {
                    ID: this.ID_ITEM,

                    TITULO: this.ITEM,
                    CAMPO_1: this.NOMBRE,
                    CAMPO_2: this.CONTROL,
                    CAMPO_3: this.MODULO,
                    CAMPO_4: this.OCULTAR,

                    ID_USUARIO: this.ID_USUARIO,
                    ID_GRUPO: this.ID,
                    ID_SEDE: this.ID_SEDE,
                    TIPO: 11,
                }).then(response => {
                    if (response.data.ID > 0) {
                        this.ListaItem = this.ListaItem.filter(x => x.ID != this.ID_ITEM);
                        this.ListaItem.push({ ID: response.data.ID, TITULO: this.ITEM, RESULTADO: this.NOMBRE, PLANTILLA: this.CONTROL, FECHA: 'AHORA', ACCIONES: this.MODULO });
                        this.ListacolumnasBD = this.ListacolumnasBD.filter(x => x.TITULO != this.ITEM);
                        this.ID_ITEM = ''; this.ITEM = ''; this.CONTROL = ''; this.NOMBRE = ''; this.OCULTAR = ''; //this.MODULO = ''; 

                        this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                    } else {
                        this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                    }
                }).catch(e => { this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error en la conexión, registro no guardado ...' }); });
            } else { this.mostrarToast({ toast: 'danger', msg: mensaje }); }
        },
        eliminarItem: function (item, index, button) {
            var opcion = confirm("Deseas eliminar el item - " + item.TITULO);
            if (opcion == true) {
                axios.post(this.SERVER_URL + '/api/Formulario/Mantenimiento', {
                    ID: item.ID,
                    ID_USUARIO: this.ID_USUARIO,
                    ID_SEDE: this.ID_SEDE,
                    TIPO: 12,
                }).then(response => {
                    if (response.data.ID > 0) {
                        this.ListaItem = this.ListaItem.filter(x => x.ID != item.ID);
                        this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                    } else {
                        this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                    }
                }).catch(e => { this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error en la conexión, registro no guardado ...' }); });
            } else { this.mostrarToast({ toast: 'warning', msg: 'Cancelado por el usuario' }); }
        },
        editarItemItem: function (item, index, button) {
            this.ListaNivel = this.ListaItem.filter(x => x.TITULO != item.TITULO && (x.PLANTILLA == 'Dropdow' || x.PLANTILLA == 'Switch'));
            this.ListaSubNivel = [];

            this.ID_ITEM = item.ID;
            this.ITEM = item.TITULO + '  |  ' + item.RESULTADO;
            this.NOMBRE = item.RESULTADO;
            this.CONTROL = item.PLANTILLA;
            this.MODULO = item.ACCIONES;
            this.OCULTAR = item.USUARIO;
            this.CHECK_DEPENDENCIA = 'False';
            this.ID_DEPENDENCIA = 0;
            this.ITEM_ITEM = '';
            this.VALOR = 0;
            this.ID_ITEM_ITEM = 0;
            this.NIVEL = { TITULO: 'SELECCIONAR' };
            this.SUB_NIVEL = { TITULO: 'SELECCIONAR' };
            this.pantalla({ PANTALLA: 'editarItemItem' })
        },
        editarItemItem2: function (item, index, button) {
            this.ID_ITEM = item.ID;
            this.MIN = '0'; this.MAX = '0'; this.ORDEN = '0';
            this.listarCampo();
            this.pantalla({ PANTALLA: 'editarItemItem2' })
        },

        guardarItemTool: function () {
            this.MIN = this.MIN.length < 1 ? 0 : this.MIN;
            this.MAX = this.MAX.length < 1 ? 0 : this.MAX;
            this.ORDEN = this.ORDEN.length < 1 ? 0 : this.ORDEN;
            axios.post(this.SERVER_URL + '/api/Formulario/Mantenimiento', {
                ID: this.ID_ITEM,

                CAMPO_1: this.MIN,
                CAMPO_2: this.MAX,
                CAMPO_3: this.ORDEN,

                ID_USUARIO: this.ID_USUARIO,
                ID_SEDE: this.ID_SEDE,
                TIPO: 16,
            }).then(response => {
                if (response.data.ID > 0) {
                    this.off({ PANTALLA: 'editarItemItem2' }); 
                    this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                } else {
                    this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                }
            }).catch(e => { this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error en la conexión, registro no guardado ...' }); });
        },
        cargarNivel: function (item) {
            this.ListaSubNivel = this.ListaItemItem.filter(x => x.ID_GRUPO == item.ID);
        },
        activarIdDependencia: function (item) {
            this.ID_DEPENDENCIA = item.ID;
        }, 
        guardarItemItem() {
            let mensaje = "Verificar los siguientes campos: ";
            mensaje = this.ITEM_ITEM.length < 1 ? mensaje + " Titulo" : mensaje;

            if (mensaje.length < 35) {
                let lista = this.ITEM_ITEM.split("|"); 
                for (var i in lista) {
                    let item = lista[i];
                    axios.post(this.SERVER_URL + '/api/Formulario/Mantenimiento', {
                        ID: this.ID_DEPENDENCIA,
                        TITULO: item, //this.ITEM_ITEM,
                        CAMPO_1: '0', // this.VALOR,

                        ID_USUARIO: this.ID_USUARIO,
                        ID_GRUPO: this.ID_ITEM,
                        ID_SEDE: this.ID_SEDE,
                        TIPO: 21, 
                    }).then(response => { 
                        if (response.data.ID > 0) {
                            this.ListaItemItem.push({ ID: response.data.ID, TITULO: item, RESULTADO: this.VALOR, PLANTILLA: '', FECHA: 'AHORA', ID_GRUPO: this.ID_ITEM, ACCIONES: this.ID_DEPENDENCIA });
                            //this.ITEM_ITEM = ''; this.VALOR = '';
                            this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                        } else { this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' }); }
                    }).catch(e => { this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error en la conexión, registro no guardado ...' }); });
                } 
                this.ITEM_ITEM = ''; this.VALOR = '';
                
            } else { this.mostrarToast({ toast: 'danger', msg: this.MensajeSistema }); }
        },
        eliminarItemItem: function (item, index, button) {
            var opcion = confirm("Deseas eliminar el item - " + item.TITULO);
            if (opcion == true) {
                axios.post(this.SERVER_URL + '/api/Formulario/Mantenimiento', {
                    ID: item.ID,
                    ID_USUARIO: this.ID_USUARIO,
                    ID_SEDE: this.ID_SEDE,
                    TIPO: 22,
                }).then(response => {
                    if (response.data.ID > 0) {
                        this.ListaItemItem = this.ListaItemItem.filter(x => x.ID != item.ID);
                        this.mostrarToast({ toast: 'success', msg: 'Guardado correctamente' });
                    } else {
                        this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error, registro no guardado ...' });
                    }
                }).catch(e => { this.mostrarToast({ toast: 'danger', msg: 'Ocurrio un error en la conexión, registro no guardado ...' }); });
            } else { this.mostrarToast({ toast: 'warning', msg: 'Cancelado por el usuario' }); }
        },

        listacolumnasBD: function () {         //  alert(JSON.stringify(this.ListaMaestra));
            axios.post(this.SERVER_URL + '/api/Formulario/Listar', {
                ID: this.ID,
                TITULO: this.CAMPO_3,
                ID_USUARIO: this.ID_USUARIO,
                ID_SEDE: this.ID_SEDE,
                TIPO: 15,
            }).then(response => {
                if (response.data.length > 0) {
                    this.ListacolumnasBD = response.data;
                    for (var i in this.ListaItem) {
                        this.ListacolumnasBD = this.ListacolumnasBD.filter(x => x.TITULO != this.ListaItem[i].TITULO);
                    }
                }
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        },
        listarCampo: function () {         //  alert(JSON.stringify(this.ListaMaestra));
            axios.post(this.SERVER_URL + '/api/Formulario/Listar', {
                ID: this.ID_ITEM,
                ID_USUARIO: this.ID_USUARIO,
                ID_SEDE: this.ID_SEDE,
                TIPO: 17,
            }).then(response => {
                if (response.data.length > 0) {
                    let lista = response.data;
                    this.MIN = lista[0].TITULO;
                    this.MAX = lista[0].RESULTADO;
                    this.ORDEN = lista[0].PLANTILLA;
                }
                
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        },

        listarFormularios: function () {         //  alert(JSON.stringify(this.ListaMaestra));
            axios.post(this.SERVER_URL + '/api/Formulario/Listar', {
                ID: this.ID,
                ID_USUARIO: this.ID_USUARIO,
                ID_SEDE: this.ID_SEDE,
                TIPO: 1,
            }).then(response => {
                this.Lista = response.data;
                this.totalRows = this.Lista.length;
                this.Lista_ = response.data;
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        },

        listarItem: function (item) {         //  alert(JSON.stringify(this.ListaMaestra));   MantenimientoPregunta
            this.ID = item.ID;
            this.FORMULARIO = item.TITULO;
            this.CAMPO_1 = item.CAMPO;
            axios.post(this.SERVER_URL + '/api/Formulario/Listar', {
                ID: this.ID,
                ID_USUARIO: this.ID_USUARIO,
                ID_SEDE: this.ID_SEDE,
                TIPO: 10, 
            }).then(response => {
                if (response.data.length > 0) {
                    this.ListaItem = response.data;
                    this.listarItemItem();
                }
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        },

        listarItemItem: function () {         //  alert(JSON.stringify(this.ListaMaestra));
            axios.post(this.SERVER_URL + '/api/Formulario/Listar', {
                ID: 0,
                ID_USUARIO: this.ID_USUARIO,
                ID_GRUPO: this.ID,
                ID_SEDE: this.ID_SEDE,
                TIPO: 20,
            }).then(response => {
                if (response.data.length > 0) { this.ListaItemItem = response.data; }
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        },

        listarFormularioVsGrupo: function () {         //  alert(JSON.stringify(this.ListaMaestra));
            axios.post(this.SERVER_URL + '/api/Formulario/Listar', {
                ID: 0,
                ID_USUARIO: this.ID_USUARIO,
                ID_GRUPO: this.ID,
                ID_SEDE: this.ID_SEDE,
                TIPO: 5,
            }).then(response => {
                if (response.data.length > 0) { this.ListaFormularioVsGrupo = response.data; }
            }).catch(e => { this.mostrarToast({ toast: 'warning', msg: 'Error en la conexión ...' }); });
        }
    }
})
app.listarFormularios();
