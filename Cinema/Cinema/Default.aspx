<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cinema._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <p runat="server" id="demo" class="alert-success"></p>
        <asp:TextBox ID="nome" runat="server"> </asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="nome" ErrorMessage="Il campo Nome è obbligatorio" />

        <asp:TextBox ID="cognome" runat="server"> </asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cognome" ErrorMessage="Il campo Cognome è obbligatorio" />

        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="SALA NORD" Value="SALA NORD"></asp:ListItem>
            <asp:ListItem Text="SALA SUD" Value="SALA SUD"></asp:ListItem>
            <asp:ListItem Text="SALA EST" Value="SALA EST"></asp:ListItem>
        </asp:DropDownList>
        <div class="d-flex mx-auto">

            <p>Biglietto ridotto?</p>
            <asp:CheckBox ID="ridotto" runat="server" />
        </div>

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

        <table class="border border-1 my-3" runat="server">
            <thead>
                <tr>
                    <th>SALA</th>
                    <th>Numero di Biglietti venduti</th>
                    <th>Numero totale biglietti ridotti venduti</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="text-center" id="Salanord" runat="server">NORD</td>
                    <td class="text-center" id="bigliettiNord" runat="server"> </td>
                    <td class="text-center" id="bigliettiRidottiNord" runat="server"> </td>

                </tr>
                <tr>
                    <td class="text-center" id="Salasud" runat="server">SUD</td>
                    <td class="text-center" id="bigliettiSud" runat="server"></td>
                    <td class="text-center" id="bigliettiRidottiSud" runat="server"></td>
                </tr>
                <tr>
                    <td class="text-center" id="SalaEst" runat="server">EST</td>
                    <td class="text-center" id="bigliettiEst" runat="server"></td>
                    <td class="text-center" id="bigliettiRidottiEst" runat="server"></td>
                </tr>
            </tbody>
        </table>
    </main>
    <script>   
</script>
</asp:Content>
