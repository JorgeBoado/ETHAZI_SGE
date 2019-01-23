<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Insertar.aspx.vb" Inherits="Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <section>
        <fieldset>
            <legend>Alojamiento</legend>
            <br />
            <section>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="firmaAc">Firma</label>
                        <asp:TextBox ID="firmaIn" runat="server" CssClass="form-control" MaxLength="25" Required="required"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="nameAc">Nombre</label>
                        <asp:TextBox ID="nameIn" runat="server" CssClass="form-control" MaxLength="50" Required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="capacityIn">Capacidad</label>
                        <asp:TextBox ID="capacityIn" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="tipoIn">Tipo</label>
                        <asp:DropDownList ID="tipoIn" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="categoryIn">Categoria</label>
                        <asp:DropDownList ID="categoryIn" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="phoneAc">Telefono</label>
                        <asp:TextBox ID="phoneIn" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="markIn">Marca</label>
                        <asp:TextBox ID="markIn" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="emailAc">Email</label>
                        <asp:TextBox ID="emailIn" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="webAc">Web</label>
                        <asp:TextBox ID="webIn" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">

                    <div class="form-group col-md-8">
                        <label for="addressAc">Direccion</label>
                        <asp:TextBox ID="addressIn" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="municipalityIn">Municipio</label>
                        <asp:DropDownList ID="municipalityIn" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-3">
                        <label for="cmAc">Codigo Municipio</label>
                        <asp:TextBox ID="cmIn" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="cpAc">Codigo Postal</label>
                        <asp:DropDownList ID="cpIn" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="coordinateIn">Coordenadas</label>
                        <asp:TextBox ID="coordinateIn" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md">
                        <label for="descripAc">Descripcion</label>
                        <asp:TextBox ID="descripIn" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="1500" Required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md">
                        <hr style="border:1px solid #7D7D7D"/>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md">
                        <label for="friendIn">FriendlyUrl</label>
                        <asp:TextBox ID="friendIn" runat="server" CssClass="form-control" MaxLength="150" Required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md">
                        <label for="physicalIn">PhysicalUrl</label>
                        <asp:TextBox ID="physicalIn" runat="server" CssClass="form-control" MaxLength="150" Required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md">
                        <label for="zipIn">ZipFile</label>
                        <asp:TextBox ID="zipIn" runat="server" CssClass="form-control" MaxLength="150" Required="required"></asp:TextBox>
                    </div>
                </div>
            </section>
        </fieldset>

    </section>

    <section>
        <div class="form-row">
            <asp:Button ID="finInsertar" runat="server" Text="Finalizar" CssClass="btn btn-success " />
            <asp:Button ID="canInsertar" runat="server" Text="Cancelar" CssClass="btn btn-success" />
        </div>
    </section>
</asp:Content>
