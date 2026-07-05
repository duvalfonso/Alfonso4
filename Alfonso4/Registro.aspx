<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Alfonso4.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container">
    <header class="py-3 mb-4 border-bottom">
      <nav>
        <ul class="nav nav-pills">
          <li class="nav-item"><a href="#registro" class="nav-link px-md-2 active">Ir a registrar</a></li>
          <li class="nav-item"><a href="#busqueda" class="nav-link px-md-2">Ir a consultar registros</a></li>
        </ul>
      </nav>
    </header>
  </div>
  <main>
    <h1 class="text-center">Registro de alumnos</h1>
    <div class="container">
      <div id="registro" class="card mb-4">
        <div class="card-header">
          <h2>Registrar</h2>
        </div>
        <div class="card-body">
          <div class="row g-3">

            <div class="col-md-4">
              <label for="txtRut" class="form-label">Rut</label>
              <asp:TextBox ID="txtRut" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-8">
              <label for="txtNombre" class="form-label">Nombre</label>
              <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
              <label for="txtNota1" class="form-label">Nota 1</label>
              <asp:TextBox
                ID="txtNota1"
                runat="server"
                CssClass="form-control"
                TextMode="Number"
                min="1"
                max="7"
                step="0.1"></asp:TextBox>
            </div>
            <div class="col-md-2">
              <label for="txtNota2" class="form-label">Nota 2</label>
              <asp:TextBox
                ID="txtNota2"
                runat="server"
                CssClass="form-control"
                TextMode="Number"
                min="1"
                max="7"
                step="0.1"></asp:TextBox>
            </div>
            <div class="col-md-2">
              <label for="txtNota3" class="form-label">Nota 3</label>
              <asp:TextBox
                ID="txtNota3"
                runat="server"
                CssClass="form-control"
                TextMode="Number"
                min="1"
                max="7"
                step="0.1"></asp:TextBox>
            </div>

            <div class="col-12">
              <asp:Button ID="btnGuardar"
                runat="server"
                Text="Guardar"
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
              <asp:Button ID="btnLimpiar"
                runat="server"
                Text="Limpiar"
                CssClass="btn btn-secondary" />
            </div>
            <div class="col-12">
              <div id="alertaIngreso" runat="server" class="alert alert-success alert-dismissible fade d-none mb-0" role="alert">
                <span id="textoAlerta" runat="server"></span>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
              </div>

            </div>
          </div>
        </div>
      </div>
      <div id="busqueda" class="card mb-4">
        <div class="card-header">
          <h3>Búsqueda</h3>
        </div>
        <div class="card-body">
          <div class="row g-3 align-items-end">
            <div class="col-md-9">
              <label for="txtBuscar" class="form-label">Rut o Nombre</label>
              <asp:TextBox
                ID="txtBuscar"
                runat="server"
                CssClass="form-control">
              </asp:TextBox>
            </div>
            <div class="col-md-3">
              <asp:Button
                ID="btnBuscar"
                runat="server"
                Text="Buscar"
                CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
              <asp:Button
                ID="btnBuscarTodos"
                runat="server"
                Text="Buscar todos"
                CssClass="btn btn-secondary" OnClick="btnBuscarTodos_Click" />
            </div>
            <div id="alertaBusqueda" runat="server" class="alert alert-success alert-dismissible fade d-none" role="alert">
              <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
          </div>
        </div>
      </div>
      <div class="col-12 mb-4">
        <div class="table-responsive">
          <asp:GridView
            ID="dgvAlumnos"
            runat="server"
            AutoGenerateColumns="true"
            EmptyDataText="No se encontraron registros."
            CssClass="table table-striped table-sm">
          </asp:GridView>
        </div>
      </div>
    </div>
  </main>
</asp:Content>
