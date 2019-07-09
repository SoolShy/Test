<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEditTea.aspx.cs" Inherits="AddEditTea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblTitle" runat="server" Text="教师基本信息"></asp:Label><br /><br />
        编号：<asp:Label ID="lblId" runat="server" Text="Label"></asp:Label><br /><br />
        工号：<asp:TextBox ID="txtTeacherId" runat="server"></asp:TextBox><br /><br />
        姓名：<asp:TextBox ID="txtTeacherName" runat="server"></asp:TextBox><br /><br />
        性别：<asp:RadioButton ID="rdoMale" runat="server" Text="男" GroupName="sex" />
        <asp:RadioButton ID="rdoFemale" runat="server" text="女" GroupName="sex"/>
        <br /><br />
        出生日期：<asp:TextBox ID="txtBirthday" runat="server"></asp:TextBox><br /><br />
        Email：<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
        &nbsp;
        <asp:Button ID="btnReset" runat="server" Text="重置" onclick="btnReset_Click" />
        &nbsp;
        <asp:Button ID="btnBack" runat="server" Text="返回" onclick="btnBack_Click" />
    </div>
    </form>
</body>
</html>
