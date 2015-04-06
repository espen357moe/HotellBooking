<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebBooking.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel ="stylesheet" type="text/css" href="StyleSheet.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Book overnatting</div>
        <p>
            Fullt navn</p>
        <asp:TextBox ID="NavnInputTextBox" Required="True" runat="server"></asp:TextBox>
        <br />
        <br />
        Innsjekkdato:<asp:Calendar ID="InnsjekkDatoCalendar" runat="server" OnSelectionChanged="InnsjekkDatoCalendar_SelectionChanged" OnDayRender="InnsjekkDatoCalendar_DayRender"></asp:Calendar>
        <br />
        Utsjekkdato:<asp:Calendar ID="UtsjekkDatoCalendar" runat="server" OnSelectionChanged="UtsjekkDatoCalendar_SelectionChanged" OnDayRender="UtsjekkDatoCalendar_DayRender"></asp:Calendar>
        <br />
        <asp:Button ID="GodkjennKnapp" runat="server" OnClick="GodkjennKnapp_Click" Text="Godkjenn" />
    </form>
</body>
</html>
