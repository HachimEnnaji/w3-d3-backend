<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cinema._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="d-flex flex-column align-items-center mb-5">
            <div class=" alert alert-success m-0 p-0" id="demo" runat="server">
            </div>
            <asp:TextBox ID="nome" runat="server" CssClass="form-control mt-2"> </asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="nome" ErrorMessage="Il campo Nome è obbligatorio" />

            <asp:TextBox ID="cognome" runat="server" CssClass="form-control"> </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cognome" ErrorMessage="Il campo Cognome è obbligatorio" />

            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select">
                <asp:ListItem Text="SALA NORD" Value="SALA NORD"></asp:ListItem>
                <asp:ListItem Text="SALA SUD" Value="SALA SUD"></asp:ListItem>
                <asp:ListItem Text="SALA EST" Value="SALA EST"></asp:ListItem>
            </asp:DropDownList>
            
                <asp:CheckBox ID="ridotto" runat="server" CssClass="form-check m-2"  Text="Biglietto ridotto?"/>
            

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" CssClass="btn btn-success" />
        </div>

        <table class="border border-1 my-3 table" runat="server">
            <thead>
                <tr>
                    <th class="text-center">SALA</th>
                    <th class="text-center">Numero di Biglietti venduti</th>
                    <th class="text-center">Numero totale biglietti ridotti venduti</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="text-center" id="SalaNord" runat="server"></td>
                    <td class="text-center" id="bigliettiNord" runat="server"></td>
                    <td class="text-center" id="bigliettiRidottiNord" runat="server"></td>

                </tr>
                <tr>
                    <td class="text-center" id="SalaSud" runat="server"></td>
                    <td class="text-center" id="bigliettiSud" runat="server"></td>
                    <td class="text-center" id="bigliettiRidottiSud" runat="server"></td>
                </tr>
                <tr>
                    <td class="text-center" id="SalaEst" runat="server"></td>
                    <td class="text-center" id="bigliettiEst" runat="server"></td>
                    <td class="text-center" id="bigliettiRidottiEst" runat="server"></td>
                </tr>
            </tbody>
        </table>
    </main>
    <script>   
</script>
</asp:Content>
