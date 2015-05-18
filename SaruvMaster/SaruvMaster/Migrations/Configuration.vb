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
                        .Nombre = "Ingenieria",
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01"),
                        .IsDeleted = 0
                    },
                    New Facultad() With {
                        .Nombre = "Ciencias De La Salud",
                        .FechaCreacion = DateTime.Parse("2011-09-01"),
                        .FechaModificacion = DateTime.Parse("2012-10-01"),
                        .IsDeleted = 0
                    },
                    New Facultad() With {
                        .Nombre = "Ciencias Administrativas",
                        .FechaCreacion = DateTime.Parse("2000-09-01"),
                        .FechaModificacion = DateTime.Parse("2012-10-01"),
                        .IsDeleted = 0
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
                        .FechaModificacion = DateTime.Parse("2012-10-01"),
                        .IsDeleted = 0
                    },
                    New AreaDeConocimiento() With {
                        .Nombre = "Fisica",
                        .FechaCreacion = DateTime.Parse("2007-09-01"),
                        .FechaModificacion = DateTime.Parse("2013-10-01"),
                        .IsDeleted = 0
                    },
                    New AreaDeConocimiento() With {
                        .Nombre = "Quimica",
                        .FechaCreacion = DateTime.Parse("2001-09-01"),
                        .FechaModificacion = DateTime.Parse("2013-10-01"),
                        .IsDeleted = 0
                    },
                    New AreaDeConocimiento() With {
                        .Nombre = "Matematicas",
                        .FechaCreacion = DateTime.Parse("2001-09-01"),
                        .FechaModificacion = DateTime.Parse("2013-10-01"),
                        .IsDeleted = 0
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
                        .Telefono = "50422554433",
                        .Ciudad = "Tegucigalpa",
                        .Departamento = "Francisco Morazan",
                        .IsDeleted = 0
                    },
                    New Empresa() With {
                        .Nombre = "Empresa XY",
                        .Direccion = "Bulevard Fuerzas Armadas",
                        .Telefono = "50422254213",
                        .Ciudad = "Tegucigalpa",
                        .Departamento = "Francisco Morazan",
                        .IsDeleted = 0
                    },
                    New Empresa() With {
                        .Nombre = "Empresa XYZ",
                        .Direccion = "Bulevard Suyapa",
                        .Telefono = "50422121433",
                        .Ciudad = "Tegucigalpa",
                        .Departamento = "Francisco Morazan",
                        .IsDeleted = 0
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
                        .Telefono = "50422123432",
                        .EmpresaID = empresas.Single(Function(e) e.Nombre = "Kielsa").ID,
                        .IsDeleted = 0
                    },
                    New ClienteCorporativo() With {
                        .Nombres = "Jeremy Leandro",
                        .Apellidos = "Galeano Funez",
                        .NumeroIdentidad = "0701-1988-10325",
                        .CorreoElectronico = "jgaleano@gmail.com",
                        .Telefono = "50422131412",
                        .EmpresaID = empresas.Single(Function(e) e.Nombre = "Kielsa").ID,
                        .IsDeleted = 0
                    },
                    New ClienteCorporativo() With {
                        .Nombres = "Ana Melissa",
                        .Apellidos = "Rivera Martinez",
                        .NumeroIdentidad = "0802-1991-13322",
                        .CorreoElectronico = "arivera@gmail.com",
                        .Telefono = "50422123456",
                        .EmpresaID = empresas.Single(Function(e) e.Nombre = "Empresa XY").ID,
                        .IsDeleted = 0
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
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingenieria").ID,
                        .Telefono = "50422113411",
                        .Extensión = "2354",
                        .correoElectronico = "ksevilla@gmail.com",
                        .IsDeleted = 0
                    },
                    New EncargadoDeValidacion() With {
                        .Nombre = "Reinaldo Jose Ruiz Chacon",
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingenieria").ID,
                        .Telefono = "50422113411",
                        .Extensión = "2353",
                        .correoElectronico = "rruiz@gmail.com",
                        .IsDeleted = 0
                    },
                    New EncargadoDeValidacion() With {
                        .Nombre = "Camila Alejandra Sierra Duarte",
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ciencias De La Salud").ID,
                        .Telefono = "50422111411",
                        .Extensión = "1001",
                        .correoElectronico = "csierra@gmail.com",
                        .IsDeleted = 0
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
                        .Apellidos = "Aguilar Santos",
                        .NumeroTalentoHumano = "13256",
                        .correoElectronico = "kavila@gmail.com",
                        .telefono = "50422116811",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Matematicas").ID,
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingenieria").ID,
                        .IsDeleted = 0
                    },
                    New Docente() With {
                        .Nombres = "Juan Carlos",
                        .Apellidos = "Leonardo Vargas",
                        .NumeroTalentoHumano = "45896",
                        .correoElectronico = "jvargas@gmail.com",
                        .telefono = "50422116812",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Matematicas").ID,
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingenieria").ID,
                        .IsDeleted = 0
                    },
                    New Docente() With {
                        .Nombres = "Samir Edgardo",
                        .Apellidos = "Castro Madrid",
                        .NumeroTalentoHumano = "10230",
                        .correoElectronico = "scastro@gmail.com",
                        .telefono = "50422196811",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Literatura").ID,
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ciencias Administrativas").ID,
                        .IsDeleted = 0
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
                        .FechaModificacion = DateTime.Parse("2012-10-01"),
                        .IsDeleted = 0
                    },
                    New ModalidadDeCurso() With {
                        .Nombre = "Corporativo",
                        .Duracion = 5,
                        .FechaCreacion = DateTime.Parse("2014-09-10"),
                        .FechaModificacion = DateTime.Parse("2014-10-10"),
                        .IsDeleted = 0
                    }
                }
            For Each m In modalidadesDeCurso
                context.ModalidadDeCurso.AddOrUpdate(Function(p) p.Nombre, m)
            Next
            context.SaveChanges()

            Dim cursos = New List(Of Curso)() From {
                    New Curso() With {
                        .Nombres = "Ecuaciones Diferenciales",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Matematicas").ID,
                        .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(e) e.Nombre = "Presencial").ID,
                        .EncargadoDeValidacionID = engargadosDeValidacion.Single(Function(e) e.Nombre = "Karina Gabriela Sevilla Ortiz").ID,
                        .FechaInicio = DateTime.Parse("2014-09-10"),
                        .FechaFinal = DateTime.Parse("2014-11-22"),
                        .Periodo = 5,
                        .FechaCreacion = DateTime.Parse("2014-09-10"),
                        .FechaModificacion = DateTime.Parse("2014-10-10"),
                        .IsDeleted = 0
                    },
                    New Curso() With {
                        .Nombres = "Quimica II",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Quimica").ID,
                        .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(e) e.Nombre = "Presencial").ID,
                        .EncargadoDeValidacionID = engargadosDeValidacion.Single(Function(e) e.Nombre = "Karina Gabriela Sevilla Ortiz").ID,
                        .FechaInicio = DateTime.Parse("2014-07-10"),
                        .FechaFinal = DateTime.Parse("2014-09-12"),
                        .Periodo = 4,
                        .FechaCreacion = DateTime.Parse("2014-09-10"),
                        .FechaModificacion = DateTime.Parse("2014-10-10"),
                        .IsDeleted = 0
                    },
                    New Curso() With {
                        .Nombres = "Fisica II",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Fisica").ID,
                        .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(e) e.Nombre = "Presencial").ID,
                        .EncargadoDeValidacionID = engargadosDeValidacion.Single(Function(e) e.Nombre = "Reinaldo Jose Ruiz Chacon").ID,
                        .FechaInicio = DateTime.Parse("2014-04-10"),
                        .FechaFinal = DateTime.Parse("2014-06-12"),
                        .Periodo = 2,
                        .FechaCreacion = DateTime.Parse("2014-09-10"),
                        .FechaModificacion = DateTime.Parse("2014-10-10"),
                        .IsDeleted = 0
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

            Dim departamentos = New List(Of Departamento)() From {
                   New Departamento() With {
                       .Nombre = "Diseno",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0
                   },
                   New Departamento() With {
                       .Nombre = "Correccion",
                       .FechaCreacion = DateTime.Parse("2011-09-01"),
                       .FechaModificacion = DateTime.Parse("2012-10-01"),
                       .IsDeleted = 0
                   },
                   New Departamento() With {
                       .Nombre = "Grabacion",
                       .FechaCreacion = DateTime.Parse("2003-09-01"),
                       .FechaModificacion = DateTime.Parse("2012-10-01"),
                       .IsDeleted = 0
                   },
                   New Departamento() With {
                       .Nombre = "Entrega",
                       .FechaCreacion = DateTime.Parse("2002-09-01"),
                       .FechaModificacion = DateTime.Parse("2012-10-01"),
                       .IsDeleted = 0
                   }
               }
            For Each dept In departamentos
                context.Departamento.AddOrUpdate(Function(p) p.Nombre, dept)
            Next
            context.SaveChanges()

            Dim rolesPorDepartamento = New List(Of RolPorDepartamento)() From {
                   New RolPorDepartamento() With {
                       .Nombre = "Jefe D",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Diseno").ID
                   },
                   New RolPorDepartamento() With {
                       .Nombre = "Auxiliar D",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Diseno").ID
                   },
                   New RolPorDepartamento() With {
                       .Nombre = "Auxiliar C",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Correccion").ID
                   },
                   New RolPorDepartamento() With {
                       .Nombre = "Auxiliar G",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Grabacion").ID
                   },
                   New RolPorDepartamento() With {
                       .Nombre = "Auxiliar E",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Entrega").ID
                   }
               }
            For Each rolDept In rolesPorDepartamento
                context.RolPorDepartamento.AddOrUpdate(Function(p) p.Nombre, rolDept)
            Next
            context.SaveChanges()

            Dim tipoDeRecursos = New List(Of TipoDeRecurso)() From {
                   New TipoDeRecurso() With {
                       .Nombre = "Polimedia",
                       .CodigoRecurso = "POL2015",
                       .FechaDeCreacion = DateTime.Parse("2010-09-01"),
                       .IsDeleted = 0
                   },
                   New TipoDeRecurso() With {
                       .Nombre = "Articulate",
                       .CodigoRecurso = "ART2015",
                       .FechaDeCreacion = DateTime.Parse("2010-09-01"),
                       .IsDeleted = 0
                   },
                   New TipoDeRecurso() With {
                       .Nombre = "Revista Digital",
                       .CodigoRecurso = "RED2015",
                       .FechaDeCreacion = DateTime.Parse("2010-09-01"),
                       .IsDeleted = 0
                   },
                   New TipoDeRecurso() With {
                       .Nombre = "Video",
                       .CodigoRecurso = "VID2015",
                       .FechaDeCreacion = DateTime.Parse("2010-09-01"),
                       .IsDeleted = 0
                   }
               }
            For Each tprec In tipoDeRecursos
                context.TipoDeRecurso.AddOrUpdate(Function(p) p.Nombre, tprec)
            Next
            context.SaveChanges()


        End Sub

    End Class

End Namespace
