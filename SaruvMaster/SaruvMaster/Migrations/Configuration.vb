Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of Connection)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As Connection)
            Dim hasher As New PasswordHasher()
            Dim departamentos = New List(Of Departamento)() From {
                   New Departamento() With {
                       .Nombre = "Diseño",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0
                   },
                   New Departamento() With {
                       .Nombre = "Corrección",
                       .FechaCreacion = DateTime.Parse("2011-09-01"),
                       .FechaModificacion = DateTime.Parse("2012-10-01"),
                       .IsDeleted = 0
                   },
                   New Departamento() With {
                       .Nombre = "Grabación",
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
            context.Savechanges()

            Dim roleStore = New RoleStore(Of IdentityRole)(context)
            Dim roleManager = New RoleManager(Of IdentityRole)(roleStore)
            Dim role As New IdentityRole() With {
                .Name = "Admin"
            }
            Dim role2 As New IdentityRole() With {
                .Name = "Estándar"
            }
            roleManager.Create(role)
            roleManager.Create(role2)


            Dim userStore = New UserStore(Of ApplicationUser)(context)
            Dim userManager = New ApplicationUserManager(userStore)
            Dim user As New ApplicationUser() With {
                .Nombre = "Wendy",
                .Apellido = "Silva",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Diseño").ID,
                .Email = "wsilva@gmail.com",
                .UserName = "wsilva@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
                .isJefe = 1
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role2.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            user = New ApplicationUser() With {
                .Nombre = "Silvia",
                .Apellido = "Colindres",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Diseño").ID,
                .Email = "scolindres@gmail.com",
                .UserName = "scolindres@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
            .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role2.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            user = New ApplicationUser() With {
                .Nombre = "Clarissa",
                .Apellido = "Lopez",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Diseño").ID,
                .Email = "clopez@gmail.com",
                .UserName = "clopez@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
            .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role2.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            user = New ApplicationUser() With {
                .Nombre = "Andrea",
                .Apellido = "Diaz",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Corrección").ID,
                .Email = "adiaz@gmail.com",
                .UserName = "adiaz@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
            .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role2.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            user = New ApplicationUser() With {
                .Nombre = "Roberto",
                .Apellido = "Martinez",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Corrección").ID,
                .Email = "rmartinez@gmail.com",
                .UserName = "rmartinez@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
            .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role2.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            user = New ApplicationUser() With {
                .Nombre = "Camilo",
                .Apellido = "Colindres",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Grabación").ID,
                .Email = "ccolindres@gmail.com",
                .UserName = "ccolindres@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
                .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role2.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            user = New ApplicationUser() With {
                .Nombre = "Gabriel",
                .Apellido = "Carcamo",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Grabación").ID,
                .Email = "gcarcamo@gmail.com",
                .UserName = "gcarcamo@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
            .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role2.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            user = New ApplicationUser() With {
                .Nombre = "Alejandra",
                .Apellido = "Davila",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Entrega").ID,
                .Email = "adavila@gmail.com",
                .UserName = "adavila@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
            .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role2.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            user = New ApplicationUser() With {
                .Nombre = "Marcelo",
                .Apellido = "Romero",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Entrega").ID,
                .Email = "mromero@gmail.com",
                .UserName = "mromero@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
                .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role2.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            'Admin
            user = New ApplicationUser() With {
                .Nombre = "Modest",
                .Apellido = "Musorgski",
                .Email = "mmusorgski@gmail.com",
                .UserName = "mmusorgski@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
                .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role.Id,
                .UserId = user.Id
            })
            userManager.Create(user)

            Dim facultades = New List(Of Facultad)() From {
                    New Facultad() With {
                        .Nombre = "Ingeniería",
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
            context.Savechanges()

            Dim areasDeConocimiento = New List(Of AreaDeConocimiento)() From {
                    New AreaDeConocimiento() With {
                        .Nombre = "Literatura",
                        .FechaCreacion = DateTime.Parse("2008-09-01"),
                        .FechaModificacion = DateTime.Parse("2012-10-01"),
                        .IsDeleted = 0
                    },
                    New AreaDeConocimiento() With {
                        .Nombre = "Física",
                        .FechaCreacion = DateTime.Parse("2007-09-01"),
                        .FechaModificacion = DateTime.Parse("2013-10-01"),
                        .IsDeleted = 0
                    },
                    New AreaDeConocimiento() With {
                        .Nombre = "Química",
                        .FechaCreacion = DateTime.Parse("2001-09-01"),
                        .FechaModificacion = DateTime.Parse("2013-10-01"),
                        .IsDeleted = 0
                    },
                    New AreaDeConocimiento() With {
                        .Nombre = "Matemáticas",
                        .FechaCreacion = DateTime.Parse("2001-09-01"),
                        .FechaModificacion = DateTime.Parse("2013-10-01"),
                        .IsDeleted = 0
                    }
                }
            For Each a In areasDeConocimiento
                context.AreaDeConocimiento.AddOrUpdate(Function(p) p.Nombre, a)
            Next
            context.Savechanges()

            Dim empresas = New List(Of Empresa)() From {
                    New Empresa() With {
                        .Nombre = "Kielsa",
                        .Direccion = "Bulevard Morazan",
                        .Telefono = "50422554433",
                        .Ciudad = "Tegucigalpa",
                        .Departamento = "Francisco Morazán",
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    },
                    New Empresa() With {
                        .Nombre = "Empresa XY",
                        .Direccion = "Bulevard Fuerzas Armadas",
                        .Telefono = "50422254213",
                        .Ciudad = "Tegucigalpa",
                        .Departamento = "Francisco Morazán",
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    },
                    New Empresa() With {
                        .Nombre = "Empresa XYZ",
                        .Direccion = "Bulevard Suyapa",
                        .Telefono = "50422121433",
                        .Ciudad = "Tegucigalpa",
                        .Departamento = "Francisco Morazán",
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    }
                }
            For Each emp In empresas
                context.Empresa.AddOrUpdate(Function(p) p.Nombre, emp)
            Next
            context.Savechanges()

            Dim clientesCorporativos = New List(Of ClienteCorporativo)() From {
                    New ClienteCorporativo() With {
                        .Nombre = "Johana Andrea",
                        .Apellidos = "Gomez Lopez",
                        .NumeroIdentidad = "0703-1990-12345",
                        .CorreoElectronico = "jgomez@gmail.com",
                        .Telefono = "50422123432",
                        .EmpresaID = empresas.Single(Function(e) e.Nombre = "Kielsa").ID,
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    },
                    New ClienteCorporativo() With {
                        .Nombre = "Jeremy Leandro",
                        .Apellidos = "Galeano Funez",
                        .NumeroIdentidad = "0701-1988-10325",
                        .CorreoElectronico = "jgaleano@gmail.com",
                        .Telefono = "50422131412",
                        .EmpresaID = empresas.Single(Function(e) e.Nombre = "Kielsa").ID,
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    },
                    New ClienteCorporativo() With {
                        .Nombre = "Ana Melissa",
                        .Apellidos = "Rivera Martinez",
                        .NumeroIdentidad = "0802-1991-13322",
                        .CorreoElectronico = "arivera@gmail.com",
                        .Telefono = "50422123456",
                        .EmpresaID = empresas.Single(Function(e) e.Nombre = "Empresa XY").ID,
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
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
            context.Savechanges()

            Dim engargadosDeValidacion = New List(Of EncargadoDeValidacion)() From {
                    New EncargadoDeValidacion() With {
                        .Nombre = "Karina Gabriela Sevilla Ortiz",
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingeniería").ID,
                        .Telefono = "50422113411",
                        .Extensión = "2354",
                        .correoElectronico = "ksevilla@gmail.com",
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    },
                    New EncargadoDeValidacion() With {
                        .Nombre = "Reinaldo Jose Ruiz Chacon",
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingeniería").ID,
                        .Telefono = "50422113411",
                        .Extensión = "2353",
                        .correoElectronico = "rruiz@gmail.com",
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    },
                    New EncargadoDeValidacion() With {
                        .Nombre = "Camila Alejandra Sierra Duarte",
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ciencias De La Salud").ID,
                        .Telefono = "50422111411",
                        .Extensión = "1001",
                        .correoElectronico = "csierra@gmail.com",
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
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
            context.Savechanges()

            Dim docentes = New List(Of Docente)() From {
                    New Docente() With {
                        .Nombres = "Karla Cecilia",
                        .Apellidos = "Aguilar Santos",
                        .NumeroTalentoHumano = "13256",
                        .correoElectronico = "kavila@gmail.com",
                        .telefono = "50422116811",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Matemáticas").ID,
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingeniería").ID,
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    },
                    New Docente() With {
                        .Nombres = "Juan Carlos",
                        .Apellidos = "Leonardo Vargas",
                        .NumeroTalentoHumano = "45896",
                        .correoElectronico = "jvargas@gmail.com",
                        .telefono = "50422116812",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Matemáticas").ID,
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ingeniería").ID,
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                    },
                    New Docente() With {
                        .Nombres = "Samir Edgardo",
                        .Apellidos = "Castro Madrid",
                        .NumeroTalentoHumano = "10230",
                        .correoElectronico = "scastro@gmail.com",
                        .telefono = "50422196811",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Literatura").ID,
                        .FacultadID = facultades.Single(Function(e) e.Nombre = "Ciencias Administrativas").ID,
                        .IsDeleted = 0,
                        .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
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
            context.Savechanges()

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
            context.Savechanges()

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
                        .FechaModificacion = DateTime.Parse("2014-10-10"),
                        .IsDeleted = 0
                    },
                    New Curso() With {
                        .Nombres = "Quimica II",
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Química").ID,
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
                        .AreaDeConocimientoID = areasDeConocimiento.Single(Function(e) e.Nombre = "Física").ID,
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
            context.Savechanges()
            Dim tipoDeRecursos = New List(Of TipoDeRecurso)() From {
                   New TipoDeRecurso() With {
                       .Nombre = "Polimedia",
                       .CodigoRecurso = "POL2015",
                       .IsDeleted = 0,
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01")
                   },
                   New TipoDeRecurso() With {
                       .Nombre = "Articulate",
                       .CodigoRecurso = "ART2015",
                       .IsDeleted = 0,
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                   },
                   New TipoDeRecurso() With {
                       .Nombre = "Revista Digital",
                       .CodigoRecurso = "RED2015",
                       .IsDeleted = 0,
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                   },
                   New TipoDeRecurso() With {
                       .Nombre = "Video",
                       .CodigoRecurso = "VID2015",
                       .IsDeleted = 0,
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                        .FechaModificacion = DateTime.Parse("2010-10-01")
                   }
               }
            For Each tprec In tipoDeRecursos
                context.TipoDeRecurso.AddOrUpdate(Function(p) p.Nombre, tprec)
            Next
            context.Savechanges()
            Dim recursos = New List(Of Recurso)() From {
                   New Recurso() With {
                       .Nombre = "Presentacion Transformada De Laplace",
                       .TipoDeRecursoID = tipoDeRecursos.Single(Function(tr) tr.Nombre = "Polimedia").Id,
                       .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(mc) mc.Nombre = "Presencial").ID,
                       .CursoID = cursos.Single(Function(c) c.Nombres = "Ecuaciones Diferenciales").ID,
                       .DocenteID = docentes.Single(Function(d) d.Nombres = "Juan Carlos").ID,
                       .Duracion = 2,
                       .Prioridad = "Alta",
                       .FechaEntrega = DateTime.Parse("2015-09-01"),
                       .IsDeleted = 0,
                       .FechaCreacion = Date.Now,
                        .FechaModificacion = Date.Now
                   },
                   New Recurso() With {
                       .Nombre = "Sea Emprendedor Hoy",
                       .TipoDeRecursoID = tipoDeRecursos.Single(Function(tr) tr.Nombre = "Video").Id,
                       .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(mc) mc.Nombre = "Corporativo").ID,
                       .EmpresaID = empresas.Single(Function(e) e.Nombre = "Kielsa").ID,
                       .ClienteCorporativoID = clientesCorporativos.Single(Function(d) d.Nombre = "Jeremy Leandro").ID,
                       .Duracion = 2,
                       .Prioridad = "Media",
                       .FechaEntrega = DateTime.Parse("2015-09-03"),
                       .IsDeleted = 0,
                       .FechaCreacion = Date.Now,
                        .FechaModificacion = Date.Now
                   },
                   New Recurso() With {
                       .Nombre = "Ondas",
                       .TipoDeRecursoID = tipoDeRecursos.Single(Function(tr) tr.Nombre = "Polimedia").Id,
                       .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(mc) mc.Nombre = "Presencial").ID,
                       .CursoID = cursos.Single(Function(c) c.Nombres = "Fisica II").ID,
                       .DocenteID = docentes.Single(Function(d) d.Nombres = "Karla Cecilia").ID,
                       .Duracion = 3,
                       .Prioridad = "Baja",
                       .FechaEntrega = DateTime.Parse("2015-09-05"),
                       .IsDeleted = 0,
                       .FechaCreacion = Date.Now,
                        .FechaModificacion = Date.Now
                   },
                   New Recurso() With {
                       .Nombre = "Alcalinos",
                       .TipoDeRecursoID = tipoDeRecursos.Single(Function(tr) tr.Nombre = "Articulate").Id,
                       .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(mc) mc.Nombre = "Presencial").ID,
                       .CursoID = cursos.Single(Function(c) c.Nombres = "Quimica II").ID,
                       .DocenteID = docentes.Single(Function(d) d.Nombres = "Karla Cecilia").ID,
                       .Duracion = 2,
                       .Prioridad = "Media",
                       .FechaEntrega = DateTime.Parse("2015-09-03"),
                       .IsDeleted = 0,
                       .FechaCreacion = Date.Now,
                        .FechaModificacion = Date.Now
                   },
                   New Recurso() With {
                       .Nombre = "Como Atender Al Cliente",
                       .TipoDeRecursoID = tipoDeRecursos.Single(Function(tr) tr.Nombre = "Video").Id,
                       .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(mc) mc.Nombre = "Corporativo").ID,
                       .EmpresaID = empresas.Single(Function(e) e.Nombre = "Empresa XY").ID,
                       .ClienteCorporativoID = clientesCorporativos.Single(Function(d) d.Nombre = "Ana Melissa").ID,
                       .Duracion = 1,
                       .Prioridad = "Alta",
                       .FechaEntrega = DateTime.Parse("2015-09-01"),
                       .IsDeleted = 0,
                       .FechaCreacion = Date.Now,
                        .FechaModificacion = Date.Now
                   },
                   New Recurso() With {
                       .Nombre = "Que Hacer En Un Simulacro",
                       .TipoDeRecursoID = tipoDeRecursos.Single(Function(tr) tr.Nombre = "Polimedia").Id,
                       .ModalidadDeCursoID = modalidadesDeCurso.Single(Function(mc) mc.Nombre = "Corporativo").ID,
                       .EmpresaID = empresas.Single(Function(e) e.Nombre = "Empresa XY").ID,
                       .ClienteCorporativoID = clientesCorporativos.Single(Function(d) d.Nombre = "Ana Melissa").ID,
                       .Duracion = 4,
                       .Prioridad = "Baja",
                       .FechaEntrega = DateTime.Parse("2015-09-10"),
                       .IsDeleted = 0,
                       .FechaCreacion = Date.Now,
                        .FechaModificacion = Date.Now
                   }
               }
            For Each rec In recursos
                context.Recurso.AddOrUpdate(Function(p) p.Nombre, rec)
            Next
            context.Savechanges()

        End Sub

    End Class

End Namespace
