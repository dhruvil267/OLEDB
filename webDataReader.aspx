<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webDataReader.aspx.cs" Inherits="OLEDB.webDataReader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Data Reader</title>
    <style type="text/css">
        .auto-style1 {
        text-decoration: underline;
        text-align: center;
        }
        .auto-style4 {
        width: 258px;
        }
        .auto-style6 {
        width: 99px;
        }
        .auto-style7 {
        height: 23px;
        width: 99px;
        }
        .auto-style5 {
        height: 23px;
        }
        .auto-style8 {
        width: 99px;
        height: 26px;
        }
        .auto-style9 {
        height: 26px;
        }
        .auto-style10 {
        width: 600px;
        }
        .auto-style11 {
        text-align: center;
        }
    </style>
</head>
<body>
    <h1 class="auto-style1"> THE DATA READER OBJECT</h1>
    <form id="form1" runat="server">
        <div>
            <table align="center" class="auto-style10">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" >Select a Course</asp:Label>
                        <br />
                        <asp:ListBox ID="lstCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstCourse_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td>
                        <table class="auto-style4" align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lblNumber" runat="server" Text="Number:"></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumber" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCourse1" runat="server" Text="Title:"></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCourse2" runat="server" Text="Duration:"></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtDuration" runat="server" ReadOnly="true" Width="25px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCourse3" runat="server" Text="Teacher:"></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtTeacher" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCourse4" runat="server" Text="Description:"></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Style="resize:none"></asp:TextBox>
                                </td>

                            </tr>

                        </table>
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="auto-style1">
                        <asp:GridView ID="gridResult" BackColor="White" BorderColor="YellowGreen" BorderStyle="None" BorderWidth="1px" CellPadding="5" GridLines="Vertical" runat="server">
                        <AlternatingRowStyle BackColor="#2D9AB2"/>
                        <FooterStyle BackColor="#D82BDE" ForeColor="Black" />
                        <HeaderStyle BackColor="#1EDE4C" ForeColor="White" Font-Bold="true" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FF5733" ForeColor="White" Font-Bold="true" />
                        <SortedAscendingCellStyle BackColor="#DAF7A6" />
                        <SortedAscendingHeaderStyle BackColor="Yellow" />
                        <SortedDescendingCellStyle BackColor="#3160CC" />
                        <SortedDescendingHeaderStyle BackColor="#17F9F2" />
                        </asp:GridView>
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11" colspan="2">&nbsp;</td>

                    <td class="auto-style11">&nbsp</td>

                </tr>

            </table>
        </div>
        <br />
        <br />
        <br />
        <br />

        <asp:GridView ID="gridTest" runat="server"></asp:GridView>
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
