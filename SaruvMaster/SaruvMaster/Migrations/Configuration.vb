Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of Connection)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As Connection)
            Dim facultades = New List(Of Facultad)() From {
                    New Facultad() With {
                        .Nombre = "Ingeniería",
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    },
                    New Facultad() With {
                        .Nombre = "Ciencias de la Salud",
                        .FechaCreacion = DateTime.Parse("2011-09-01"),
                        .FechaModificacion = DateTime.Parse("2012-10-01")
                    },
                    New Facultad() With {
                        .Nombre = "Ciencias Administrativas",
                        .FechaCreacion = DateTime.Parse("2000-09-01"),
                        .FechaModificacion = DateTime.Parse("2012-10-01")
                    }
                }
            For Each f In facultades
                context.Facultad.AddOrUpdate(Function(p) p.Nombre, f)
            Next
            context.SaveChanges()

            Dim areasDeConocimiento = New List(Of AreaDeConocimiento)() From {
                    New AreaDeConocimiento() With {
                        .Nombre = "Literatura",
                        .FechaCreacion = DateTime.Parse("2008-09-01"),
                        .FechaModificacion = DateTime.Parse("2012-10-01")
                    },
                    New AreaDeConocimiento() With {
                        .Nombre = "Física",
                        .FechaCreacion = DateTime.Parse("2007-09-01"),
                        .FechaModificacion = DateTime.Parse("2013-10-01")
                    },
                    New AreaDeConocimiento() With {
                        .Nombre = "Química",
                        .FechaCreacion = DateTime.Parse("2001-09-01"),
                        .FechaModificacion = DateTime.Parse("2013-10-01")
                    },
                    New AreaDeConocimiento() With {
                        .Nombre = "Matemáticas",
                        .FechaCreacion = DateTime.Parse("2001-09-01"),
                        .FechaModificacion = DateTime.Parse("2013-10-01")
                    }
                }
            For Each a In areasDeConocimiento
                context.AreaDeConocimiento.AddOrUpdate(Function(p) p.Nombre, a)
            Next
            context.SaveChanges()

            Dim empresas = New List(Of Empresa)() From {
                    New Empresa() With {
                        .Nombre = "Kielsa",
                        .Direccion = "Bulevard Morazan",
                        .Telefono = "(504)-22554433",
                        .Ciudad = "Tegucigalpa",
                        .Departamento = "Francisco Morazan"
                    },
                    New Empresa() With {
                        .Nombre = "Empresa X",
                        .Direccion = "Bulevard Fuerzas Armadas",
                        .Telefono = "(504)-22254213",
                        .Ciudad = "Tegucigalpa",
                        .Departamento = "Francisco Morazan"
                    },
                    New Empresa() With {
                        .Nombre = "Empresa XYZ",
                        .Direccion = "Bulevard Suyapa",
                        .Telefono = "(504)-22121433",
                        .Ciudad = "Tegucigalpa",
                        .Departamento = "Francisco Morazan"
                    }
                }
            For Each emp In empresas
                context.Empresa.AddOrUpdate(Function(p) p.Nombre, emp)
            Next
            context.SaveChanges()

            Dim clientesCorporativos = New List(Of ClienteCorporativo)() From {
                    New ClienteCorporativo() With {
                        .Nombres = "Johana Andrea",
                        .Apellidos = "Gomez Lopez",
                        .NumeroIdentidad = "0703-1990-12345",
                        .CorreoElectronico = "jgomez@gmail.com",
                        .Telefono = "(504)-22123432",
                        .EmpresaID = empresas.Single(Function(e) e.Nombre = "Kielsa").ID
                    },
                    New ClienteCorporativo() With {
                        .Nombres = "Jeremy Leandro",
                        .Apellidos = "Galeano Funez",
                        .NumeroIdentidad = "0701-1988-10325",
                        .CorreoElectronico = "jgaleano@gmail.com",
                        .Telefono = "(504)-22131412",
                        .EmpresaID = empresas.Single(Function(e) e.Nombre = "Kielsa").ID
                    },
                    New ClienteCorporativo() With {
                        .Nombres = "Ana Melissa",
                        .Apellidos = "Rivera Martinez",
                        .NumeroIdentidad = "0802-1991-13322",
                        .CorreoElectronico = "arivera@gmail.com",
                        .Telefono = "(504)-22123456",
                        .EmpresaID = empresas.Single(Function(e) e.Nombre = "Empresa X").ID
                    }
                }
            For Each c As ClienteCorporativo In clientesCorporativos
                Try
                    Dim clienteEnDb = context.ClienteCorporativo.Where(Function(s) s.EmpresaID = c.EmpresaID).SingleOrDefault()
                    If clienteEnDb Is Nothing Then
                        context.ClienteCorporativo.Add(c)
                    End If
                Catch ex As Exception
                End Try
            Next
            context.SaveChanges()

            Dim engargadosDeValidacion = New List(Of EncargadoDeValidacion)() From {
                    New EncargadoDeValidacion() With {
                        .Nombre = "Karina Gabriela Sevilla Ortiz",
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingeniería").ID,
                        .Telefono = "(504)-22113411",
                        .Extensión = "2354",
                        .correoElectronico = "ksevilla@gmail.com"
                    },
                    New EncargadoDeValidacion() With {
                        .Nombre = "Reinaldo José Ruiz Chacón",
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingeniería").ID,
                        .Telefono = "(504)-22113411",
                        .Extensión = "2353",
                        .correoElectronico = "rruiz@gmail.com"
                    },
                    New EncargadoDeValidacion() With {
                        .Nombre = "Camila Alejandra Sierra Duarte",
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ciencias de la Salud").ID,
                        .Telefono = "(504)-22111411",
                        .Extensión = "1001",
                        .correoElectronico = "csierra@gmail.com"
                    }
                }
            For Each en As EncargadoDeValidacion In engargadosDeValidacion
                Try
                    Dim encargadoEnDb = context.EncargadoDeValidacion.Where(Function(s) s.FacultadID = en.FacultadID).SingleOrDefault()
                    If encargadoEnDb Is Nothing Then
                        context.EncargadoDeValidacion.Add(en)
                    End If
                Catch ex As Exception
                End Try
            Next
            context.SaveChanges()

            Dim docentes = New List(Of Docente)() From {
                    New Docente() With {
                        .Nombres = "Karla Cecilia",
                        .Apellidos = "Águilar Santos",
                        .NumeroTalentoHumano = "13256",
                        .correoElectronico = "kavila@gmail.com",
                        .telefono = "(504)-22116811",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Matemáticas").ID,
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingeniería").ID
                    },
                    New Docente() With {
                        .Nombres = "Juan Carlos",
                        .Apellidos = "Leonardo Vargas",
                        .NumeroTalentoHumano = "45896",
                        .correoElectronico = "jvargas@gmail.com",
                        .telefono = "(504)-22116812",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Matemáticas").ID,
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingeniería").ID
                    },
                    New Docente() With {
                        .Nombres = "Samir Edgardo",
                        .Apellidos = "Castro Madrid",
                        .NumeroTalentoHumano = "10230",
                        .correoElectronico = "scastro@gmail.com",
                        .telefono = "(504)-22196811",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Literatura").ID,
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ciencias Administrativas").ID
                    }
                }
            For Each doc As Docente In docentes
                Try
                    Dim docenteEnDb = context.Docente.Where(Function(s) s.FacultadID = doc.FacultadID AndAlso s.AreaDeConocimientoID = doc.AreaDeConocimientoID).SingleOrDefault()
                    If docenteEnDb Is Nothing Then
                        context.Docente.Add(doc)
                    End If
                Catch ex As Exception
                End Try
            Next
            context.SaveChanges()

            Dim modalidadesDeCurso = New List(Of ModalidadDeCurso)() From {
                    New ModalidadDeCurso() With {
                        .Nombre = "Presencial",
                        .Duracion = 10,
                        .FechaCreacion = DateTime.Parse("2008-09-01"),
                        .FechaModificacion = DateTime.Parse("2012-10-01")
                    },
                    New ModalidadDeCurso() With {
                        .Nombre = "Internacional",
                        .Duracion = 5,
                        .FechaCreacion = DateTime.Parse("2014-09-10"),
                        .FechaModificacion = DateTime.Parse("2014-10-10")
                    }
                }
            For Each m In modalidadesDeCurso
                context.ModalidadDeCurso.AddOrUpdate(Function(p) p.Nombre, m)
            Next
            context.SaveChanges()

            Dim cursos = New List(Of Curso)() From {
                    New Curso() With {
                        .Nombres = "Ecuaciones Diferenciales",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Matemáticas").ID,
                        .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(e) e.Nombre = "Presencial").ID,
                        .EncargadoDeValidacionID = engargadosDeValidacion.Single(Function(e) e.Nombre = "Karina Gabriela Sevilla Ortiz").ID,
                        .FechaInicio = DateTime.Parse("2014-09-10"),
                        .FechaFinal = DateTime.Parse("2014-11-22"),
                        .Periodo = 5,
                        .FechaCreacion = DateTime.Parse("2014-09-10"),
                        .FechaModificacion = DateTime.Parse("2014-10-10")
                    },
                    New Curso() With {
                        .Nombres = "Química I",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Química").ID,
                        .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(e) e.Nombre = "Presencial").ID,
                        .EncargadoDeValidacionID = engargadosDeValidacion.Single(Function(e) e.Nombre = "Karina Gabriela Sevilla Ortiz").ID,
                        .FechaInicio = DateTime.Parse("2014-07-10"),
                        .FechaFinal = DateTime.Parse("2014-09-12"),
                        .Periodo = 4,
                        .FechaCreacion = DateTime.Parse("2014-09-10"),
                        .FechaModificacion = DateTime.Parse("2014-10-10")
                    },
                    New Curso() With {
                        .Nombres = "Física II",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Física").ID,
                        .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(e) e.Nombre = "Presencial").ID,
                        .EncargadoDeValidacionID = engargadosDeValidacion.Single(Function(e) e.Nombre = "Reinaldo José Ruiz Chacón").ID,
                        .FechaInicio = DateTime.Parse("2014-04-10"),
                        .FechaFinal = DateTime.Parse("2014-06-12"),
                        .Periodo = 2,
                        .FechaCreacion = DateTime.Parse("2014-09-10"),
                        .FechaModificacion = DateTime.Parse("2014-10-10")
                    }
                }
            For Each cur As Curso In cursos
                Try
                    Dim cursoEnDb = context.Curso.Where(Function(s) s.ModalidadDeCursoID = cur.ModalidadDeCursoID AndAlso s.AreaDeConocimientoID = cur.AreaDeConocimientoID AndAlso s.EncargadoDeValidacionID = cur.EncargadoDeValidacionID).SingleOrDefault()
                    If cursoEnDb Is Nothing Then
                        context.Curso.Add(cur)
                    End If
                Catch ex As Exception
                End Try
            Next
            context.SaveChanges()
        End Sub

    End Class

End Namespace
