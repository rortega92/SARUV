<!--sidebar start-->
<aside>
    <div id="sidebar" class="nav-collapse ">
        <!-- sidebar menu start-->
        <ul class="sidebar-menu">
            @If User.IsInRole("Admin").Equals(True) Then
            @<li Class="sub-menu">
                <a href = " javascript:;" Class="">
                    <i Class="icon_document_alt"></i>
                    <span> Administración</span>
                </a>
                <ul Class="sub">
                    <li> <a Class="" href="#">Reporte de Tareas</a></li>
                    <li> <a Class="" href="#">Estudio de Grabación</a></li>
                    <li> <a Class="" href="#">Eventos UV</a></li>
                </ul>
            </li>

            @<li Class="sub-menu">
                <a style = "display:flex;" href="javascript:;" Class="">
                    <i Class="icon_table"></i>
                    <span> Registro de Datos</span>
                </a>
                <ul Class="sub">
                    <li> <a Class="" href="/AreaDeConocimiento">Área de Conocimiento</a></li>
                    <li> <a Class="" href="/ClienteCorporativo">Cliente Corporativo</a></li>
                    <li> <a Class="" href="/Curso">Curso</a></li>
                    <li> <a Class="" href="/Docente">Docente</a></li>
                    <li> <a Class="" href="/Departamento">Departamento</a></li>
                    <li> <a Class="" href="/Empresa">Empresa</a></li>
                    <li> <a Class="" href="/EncargadoDeValidacion">Encargado de Validación</a></li>
                    <li> <a Class="" href="/Facultad">Facultad</a></li>
                    <li> <a Class="" href="/ModalidadDeCurso">Modalidad de Curso</a></li>
                    <li> <a Class="" href="/TipoDeRecurso">Tipo de Recurso</a></li>
                    <li> <a Class="" href="/Recurso">Recurso</a></li>
                    <li> <a Class="" href="/RolPorDepartamento">Rol por Departamento</a></li>
                    <li> <a Class="" href="/Usuario">Usuario</a></li>
                </ul>
            </li>
            End If

            @If User.IsInRole("Estandar").Equals(True) Then
            @<li Class="sub-menu">
                <a href = " javascript:;" Class="">
                    <i Class="icon_document_alt"></i>
                    <span> Universidad Virtual</span>
                </a>
                <ul Class="sub">
                    <li> <a Class="" href="#">Eventos UV</a></li>
                </ul>
            </li>
            End If

        </ul>
        <!-- sidebar menu end-->
    </div>
</aside>
<!--sidebar end-->