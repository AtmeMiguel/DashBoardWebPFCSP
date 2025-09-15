using appCalidad.Infraestructura.Datos.Repository;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using ClosedXML.Excel;
using iText.IO.Font.Constants;
//using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
//using iText.Kernel.Geom;
//using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private DUsuarioHandlers Dusuario;
        private DFormularioHandlers DFormulario;
        private DComunicadoHandlers DComunicado;
        // GET: Admin
        public AdminController()
        {
            Dusuario = new DUsuarioHandlers();
            DFormulario = new DFormularioHandlers();
            DComunicado = new DComunicadoHandlers();
        }
        public ActionResult Rol()
        {
            return View();
        }

        public ActionResult Formulario()
        {
            return View();
        }

        public ActionResult Formulario_II()
        {
            return View();
        }

        public ActionResult Reporte()
        {
            return View();
        }

        public ActionResult Modulo()
        {
            return View();
        }
        public ActionResult Tipificar()
        {
            return View();
        }

        public ActionResult TipificarMacroIMRINA()
        {
            return View();
        }
        public ActionResult Comunicado()
        {
            return View();
        }
        public ActionResult Enlace()
        {
            return View();
        }

        public ActionResult Grupo()
        {
            return View();
        }

        public ActionResult Usuario()
        {
            string usuarioIdentity = User.Identity.Name;

            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        public ActionResult Pdf()
        {
            byte[] password = Encoding.ASCII.GetBytes("User");
            byte[] passOwner = Encoding.ASCII.GetBytes("Password1");

            MemoryStream ms = new MemoryStream();
            PdfWriter pw = new PdfWriter(ms, new WriterProperties()
                .AddXmpMetadata()
                .SetPdfVersion(PdfVersion.PDF_1_7)
                // Restringe Copiar, imprimir, 
                .SetStandardEncryption(password, passOwner, 0, EncryptionConstants.ENCRYPTION_AES_256)
                //.SetStandardEncryption(password, passOwner, EncryptionConstants.ALLOW_PRINTING | EncryptionConstants.ALLOW_COPY | EncryptionConstants.ALLOW_ASSEMBLY, EncryptionConstants.ENCRYPTION_AES_256)
                );
            PdfDocument pdfDocument = new PdfDocument(pw);

            // Begin Metadata
            PdfDocumentInfo info = pdfDocument.GetDocumentInfo();
            info.SetTitle("Titulo");
            info.SetAuthor("Autor");
            info.SetSubject("Asunto");
            info.SetKeywords("Palabras clave");
            info.SetCreator("Creador");

            Document doc = new Document(pdfDocument, iText.Kernel.Geom.PageSize.LETTER);
            doc.SetMargins(75, 35, 70, 35);

            //string namefont= Server.MapPath("/fonts/")
            //PdfFont font = PdfFontFactory.CreateFont(FontConstants.HELVETICA);
            string pathLogo = Server.MapPath("~/Recursos/descarga.png");
            Image img = new Image(iText.IO.Image.ImageDataFactory.Create(pathLogo));
            pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));


            Table table = new Table(1).UseAllAvailableWidth();
            Cell cell = new Cell().Add(new Paragraph("Reporte de Asistencia").SetFontSize(14)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBackgroundColor(ColorConstants.WHITE, 0)
                .SetBorder(Border.NO_BORDER));
            table.AddCell(cell);
            cell = new Cell().Add(new Paragraph("Sub titulo")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBackgroundColor(ColorConstants.WHITE, 0)
                .SetBorder(Border.NO_BORDER));
            table.AddCell(cell);
            table.SetMarginBottom(10f);
            doc.Add(table);

            Style styleCell = new Style()
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetTextAlignment(TextAlignment.CENTER);

            Table _table = new Table(4).UseAllAvailableWidth();
            Cell _cell = new Cell(2, 1).Add(new Paragraph("# ID"));
            _table.AddCell(_cell.AddStyle(styleCell));
            _cell = new Cell(1, 2).Add(new Paragraph("Datos personales"));
            _table.AddCell(_cell.AddStyle(styleCell));
            _cell = new Cell(2, 1).Add(new Paragraph("Usuario"));
            _table.AddCell(_cell.AddStyle(styleCell));
            _cell = new Cell().Add(new Paragraph("Nombres"));
            _table.AddCell(_cell.AddStyle(styleCell));
            _cell = new Cell().Add(new Paragraph("Apellidos"));
            _table.AddCell(_cell.AddStyle(styleCell));

            TRequest Us = new TRequest();
            List<UsuarioResponses> listaUsuarios = Dusuario.ListarUsuarios(Us);
            int x = 0;
            foreach (var item in listaUsuarios)
            {
                x++;
                //_cell = new Cell().Add(new Paragraph(x.ToString()));
                //_table.AddCell(_cell);
                if (item.ID < 5)
                {
                    _cell = new Cell().Add(new Paragraph("N° " + item.ID));
                    _table.AddCell(_cell.SetBackgroundColor(ColorConstants.RED));
                }
                else
                {
                    _cell = new Cell().Add(new Paragraph("N° " + item.ID));
                    _table.AddCell(_cell.SetBackgroundColor(ColorConstants.GREEN));
                }
                _cell = new Cell().Add(new Paragraph(item.NOMBRES));
                _table.AddCell(_cell.SetBackgroundColor(ColorConstants.ORANGE));
                _cell = new Cell().Add(new Paragraph(item.APELLIDOS));
                _table.AddCell(_cell.SetBackgroundColor(ColorConstants.YELLOW));
                _cell = new Cell().Add(new Paragraph(item.USUARIO));
                _table.AddCell(_cell);
            }
            doc.Add(_table);

            doc.Add(new Paragraph("Hello").SetFontColor(ColorConstants.BLUE));

            doc.Close();

            byte[] bytesStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;

            return new FileStreamResult(ms, "application/pdf");
        }

        public class HeaderEventHandler1 : IEventHandler
        {
            Image Img;
            public HeaderEventHandler1(Image img)
            {
                Img = img;
            }

            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = @event as PdfDocumentEvent;
                PdfDocument pdfDOc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();

                iText.Kernel.Geom.Rectangle rootArea = new iText.Kernel.Geom.Rectangle(35, page.GetPageSize().GetTop() - 70, page.GetPageSize().GetRight() - 70, 50);

                Canvas canvas = new Canvas(page, rootArea);
                canvas
                    .Add(getTable(docEvent))
                    .ShowTextAligned("Este es el encabezado de página", 10, 0, TextAlignment.CENTER)
                    .ShowTextAligned("Este es el pie de página", 10, 10, TextAlignment.CENTER)
                    .ShowTextAligned("Texto agregado", 612, 0, TextAlignment.RIGHT)
                    .Close();

            }

            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] celWidth = { 20f, 80f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(celWidth)).UseAllAvailableWidth();

                Style styleCell = new Style()
                    .SetBorder(Border.NO_BORDER);

                Style styleText = new Style()
                    .SetTextAlignment(TextAlignment.RIGHT).SetFontSize(10f);

                Cell cell = new Cell().Add(Img.SetAutoScale(true)).SetBorder(new SolidBorder(ColorConstants.WHITE, 0));

                tableEvent.AddCell(cell.AddStyle(styleCell)
                    .SetTextAlignment((TextAlignment)TextAlignment.LEFT));
                PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
                cell = new Cell()
                    .Add(new Paragraph("Reporte diario").SetFont(bold))
                    .Add(new Paragraph("Departaento de sistemas").SetFont(bold))
                    .Add(new Paragraph("Fecha de emisión" + DateTime.Now.ToShortDateString()))
                    .AddStyle(styleText).AddStyle(styleCell)
                    .SetBorder(new SolidBorder(ColorConstants.WHITE, 0));

                tableEvent.AddCell(cell);

                return tableEvent;

            }

        }

        public ActionResult ImageFormulario(string idFormulario, string idUsuario)
        {
            Session["ID_FORMULARIO"] = idFormulario;
            Session["ID_USUARIO"] = idUsuario;
            ViewBag.Message = "Iniciando proceso de carga:";
            return View();
        }

        [HttpPost]
        public ActionResult ImageFormulario(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string strFolder = Server.MapPath("~/Recursos/Examen");
                    if (!Directory.Exists(strFolder))
                    {
                        Directory.CreateDirectory(strFolder);
                    }
                    var allowedExtensions = new[] { ".pdf", ".zip", ".rar" };
                    var idPregunta = Session["ID_FORMULARIO"] as string;

                    var extension = Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Recursos/Examen"), Path.GetFileName(idPregunta + extension));
                    file.SaveAs(path);

                    //  INSERTAR EXT ( COMUNICADO )
                    FormularioRequest Form = new FormularioRequest();
                    Form.ID = Convert.ToInt32(idPregunta);
                    Form.CAMPO_2 = file.FileName;
                    Form.CAMPO_1 = extension;
                    Form.ID_USUARIO = Convert.ToInt32(Session["ID_USUARIO"]);
                    Form.ID_SEDE = 1;
                    Form.TIPO = 14;

                    TResponses respuesta = DFormulario.MantenimientoPregunta(Form);
                    if (respuesta.ID > 0)
                    {
                        ViewBag.ID = respuesta.ID;
                        ViewBag.Message = respuesta.RESULTADO;
                    }
                }
                else
                {
                    ViewBag.ID = 0;
                    ViewBag.Message = "Archivo incorrecto";
                }
            }
            catch (Exception e)
            {
                ViewBag.ID = 0;
                ViewBag.Message = e.Message;
            }
            //ViewBag.Message = "Cargado correctamente";

            return View();
        }

        public ActionResult ImageComunicado(string idComunicado, string idUsuario)
        {
            Session["ID_COMUNICADO"] = idComunicado;
            Session["ID_USUARIO"] = idUsuario;
            ViewBag.Message = "Iniciando proceso de carga:";
            return View();
        }

        [HttpPost]
        public ActionResult ImageComunicado(HttpPostedFileBase file)
        {
            try
            {
                ViewBag.Message = "";
                if (file != null && file.ContentLength > 0 )//(1 * 1024))
                {
                    string strFolder = Server.MapPath("~/Recursos/Comunicado");
                    // Create the folder if it does not exist.
                    if (!Directory.Exists(strFolder))
                    {
                        Directory.CreateDirectory(strFolder);
                    }
                    var idComunicado = Session["ID_COMUNICADO"] as string;
                    var extension = Path.GetExtension(file.FileName);
                    var allowedExtensions = new[] { ".png", ".jpg", ".gif", ".jpeg" };
                    //string path = Path.Combine(Server.MapPath("~/Recursos/Comunicado"), Path.GetFileName(idComunicado + extension));
                    string path = Path.Combine(strFolder, Path.GetFileName(idComunicado + extension));

                    if (allowedExtensions.Contains(extension))
                    {
                        file.SaveAs(path);

                        ComunicadoRequest Com = new ComunicadoRequest();
                        Com.ID = Convert.ToInt32(idComunicado);
                        Com.BANNER = file.FileName;
                        Com.TITULO = "";
                        Com.EXT = extension;
                        Com.ID_USUARIO = Convert.ToInt32(Session["ID_USUARIO"]);
                        Com.ID_SEDE = 0;
                        Com.TIPO = 4;

                        TResponses respuesta = DComunicado.MantenimientoComunicado(Com);
                        if (respuesta.ID > 0)
                        {
                            ViewBag.ID = respuesta.ID;
                            ViewBag.Message = respuesta.RESULTADO;
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Archivo incorrecto";
                }
            }
            catch (Exception e)
            {
                ViewBag.ID = 0;
                ViewBag.Message = e.Message;
            }
            //ViewBag.Message = "Cargado correctamente";
            return View();
        }

        public ActionResult ExcelUsuarios(string idGrupo, string idPrograma, string idUsuario)
        {
            Session["ID_GRUPO"] = idGrupo;
            Session["ID_SEDE"] = idPrograma;
            Session["ID_USUARIO"] = idUsuario;
            return View();
        }
        [HttpPost]
        public ActionResult ExcelUsuarios(HttpPostedFileBase file)
        {
            DataTable dt = new DataTable();//Customer_ID
            List<TResponses> ListaRespuesta = new List<TResponses>();
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Recursos/Excel"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    using (XLWorkbook workbook = new XLWorkbook(path))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool FirstRow = true;
                        //Range for reading the cells based on the last cell used.
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (FirstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Columns.Add(cell.Value.ToString());
                                }
                                // AUMENTADO
                                dt.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                                // AUMENTADO

                                FirstRow = false;
                            }
                            else
                            {
                                dt.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }

                        if (FirstRow)
                        {
                            ViewBag.Message = "El documento excel no contiene registros!";
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Archivo incorrecto, verificar archivo con extensión .xlsx!";
                }

                bool FirstRow1 = true;
                foreach (DataRow row in dt.Rows)
                {
                    if (FirstRow1)
                    {
                        FirstRow1 = false;
                    }
                    else
                    {
                        UsuarioRequest Us = new UsuarioRequest();
                        Us.ID = 0;
                        Us.USUARIO = row[0].ToString();
                        Us.NOMBRES = row[1].ToString();
                        Us.APELLIDOS = row[2].ToString();
                        Us.PASSWORD = row[0].ToString();
                        Us.ID_GRUPO = Convert.ToInt32(Session["ID_GRUPO"]);
                        Us.ID_SEDE = Convert.ToInt32(Session["ID_SEDE"]);
                        Us.ID_USUARIO = Convert.ToInt32(Session["ID_USUARIO"]);
                        TResponses us = Dusuario.MantenimientoUsuario(Us);
                        ListaRespuesta.Add(us);
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            ViewBag.Listado = ListaRespuesta;

            return View();
        }

        public ActionResult ExcelEliminarUsuarios(string idGrupo, string idPrograma, string idUsuario)
        {
            Session["ID_GRUPO"] = idGrupo;
            Session["ID_SEDE"] = idPrograma;
            Session["ID_USUARIO"] = idUsuario;
            return View();
        }
        [HttpPost]
        public ActionResult ExcelEliminarUsuarios(HttpPostedFileBase file)
        {
            DataTable dt = new DataTable();//Customer_ID
            List<TResponses> ListaRespuesta = new List<TResponses>();
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Recursos/Excel"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    using (XLWorkbook workbook = new XLWorkbook(path))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool FirstRow = true;
                        //Range for reading the cells based on the last cell used.
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (FirstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Columns.Add(cell.Value.ToString());
                                }
                                // AUMENTADO
                                dt.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                                // AUMENTADO

                                FirstRow = false;
                            }
                            else
                            {
                                dt.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }

                        if (FirstRow)
                        {
                            ViewBag.Message = "El documento excel no contiene registros!";
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Archivo incorrecto, verificar archivo con extensión .xlsx!";
                }
                bool FirstRow1 = true;
                foreach (DataRow row in dt.Rows)
                {
                    if (FirstRow1)
                    {
                        FirstRow1 = false;
                    }
                    else
                    {
                        UsuarioRequest Us = new UsuarioRequest();
                        Us.ID = 0;
                        Us.USUARIO = row[0].ToString();
                        Us.ID_GRUPO = Convert.ToInt32(Session["ID_GRUPO"]);
                        Us.ID_SEDE = Convert.ToInt32(Session["ID_SEDE"]);
                        Us.ID_USUARIO = Convert.ToInt32(Session["ID_USUARIO"]);
                        TResponses us = Dusuario.MantenimientoUsuario(Us);
                        ListaRespuesta.Add(us);
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            ViewBag.Listado = ListaRespuesta;

            return View();
        }

        public ActionResult ExcelPreguntas(string idUsuario, string idPrograma)
        {
            Session["ID_USUARIO"] = idUsuario;
            Session["ID_SEDE"] = idPrograma;
            return View();
        }
        [HttpPost]
        public ActionResult ExcelPreguntas(HttpPostedFileBase file)
        {
            DataTable dt = new DataTable();//Customer_ID
            List<TResponses> ListaRespuesta = new List<TResponses>();
            int idUsuario = Convert.ToInt32(Session["ID_USUARIO"]);
            int idPrograma = Convert.ToInt32(Session["ID_SEDE"]);
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Recursos/Excel"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    using (XLWorkbook workbook = new XLWorkbook(path))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool FirstRow = true;
                        //Range for reading the cells based on the last cell used.
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (FirstRow)
                            {
                                readRange = string.Format("{0}:{1}", 2, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Columns.Add(cell.Value.ToString());
                                }
                                FirstRow = false;
                            }
                            else
                            {
                                dt.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                        if (FirstRow)
                        {
                            ViewBag.Message = "El documento excel no contiene registros!";
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Archivo incorrecto, verificar archivo con extensión .xlsx!";
                }

                //var canalUsuario = Session["ID_USUARIO"] as string;
                bool FirstRow1 = true;
                //  INSERTAR FORMULARIO ( EXAMEN )
                FormularioRequest Form = new FormularioRequest();
                Form.ID = 0;
                Form.TITULO = file.FileName;
                Form.CAMPO_1 = "0";
                Form.CAMPO_2 = "";
                Form.CAMPO_3 = "";
                Form.ID_USUARIO = idUsuario;
                Form.ID_SEDE = idPrograma;
                Form.TIPO = 2;

                TResponses Frm = DFormulario.MantenimientoFormulario(Form);
                int idFormulario = Frm.ID;
                int idPregunta = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (FirstRow1)
                    {
                        FirstRow1 = false;
                    }
                    else
                    {
                        if (row[2].ToString() == "P")  // INSERTAR PREGUNTA
                        {
                            //  INSERTAR FORMULARIO ( EXAMEN )
                            FormularioRequest Pre = new FormularioRequest();
                            Pre.ID = 0;
                            Pre.TITULO = row[1].ToString();

                            Pre.ID_USUARIO = idUsuario;
                            Pre.ID_SEDE = idFormulario;
                            Pre.TIPO = 11;
                            TResponses Pr = DFormulario.MantenimientoPregunta(Pre);
                            idPregunta = Pr.ID;
                            ListaRespuesta.Add(Pr);
                        }
                        if (row[2].ToString() == "A")  // INSERTAR RESPUESTA
                        {
                            //  INSERTAR FORMULARIO ( EXAMEN )
                            FormularioRequest Res = new FormularioRequest();
                            Res.ID = 0;
                            Res.TITULO = row[1].ToString();
                            Res.CAMPO_1 = row[3].ToString();

                            Res.ID_USUARIO = idUsuario;
                            Res.ID_SEDE = idPregunta;
                            Res.TIPO = 21;
                            TResponses Re = DFormulario.MantenimientoRespuesta(Res);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            ViewBag.Listado = ListaRespuesta;

            return View();
        }
    }
}