<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="character.aspx.cs" Inherits="tWWWProject.character" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="style.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="grid2x2">
        
            <div class="Information">
                
               <table class="InfoDiv">
                  <tr>
                    <th>Name</th>
                    <th><asp:TextBox ID="Name" width="80px" MaxLength="255" runat="server"></asp:TextBox></th>                    
                  </tr>
                  <tr>
                    <td>Age</td>
                    <td><asp:TextBox ID="Age"  width="80px" MaxLength="255"  runat="server"></asp:TextBox></td>                    
                  </tr>
                  <tr>
                    <td>Occupation</td>
                    <td><asp:TextBox ID="Occupation"  width="80px" MaxLength="255" runat="server"></asp:TextBox></td>                    
                  </tr>
                   <tr>
                    <td>Characteristics</td>
                    <td><asp:TextBox ID="Characteristics"  width="80px" MaxLength="255" runat="server"></asp:TextBox></td>                    
                  </tr>
                   <tr>
                    <td>Despises</td>
                    <td><asp:TextBox ID="Despises"  width="80px" MaxLength="255" runat="server"></asp:TextBox></td>                    
                  </tr>
                   <tr>
                    <td>Afinity</td>
                    <td><asp:TextBox ID="Afinity"  width="80px" MaxLength="255" runat="server"></asp:TextBox></td>                    
                  </tr>
                   <tr>
                    <td>Gear</td>
                    <td><asp:TextBox ID="Gear"  width="80px" MaxLength="255" runat="server"></asp:TextBox></td>               
                  </tr>
                </table> 

            </div>
                  
            
            <div class="Avatar">                              
                <img class="AvatarChoosing" runat="server" id="avatarimage" width="500" height="400" src="Resources/0.jpg"/>
                    <div>
                <asp:RadioButton id="Image0" Text="Image 0" Checked="True" GroupName="Images" runat="server" OnCheckedChanged="Image0_CheckedChanged" AutoPostBack="true" />
                <asp:RadioButton id="Image1" Text="Image 1" GroupName="Images" runat="server" OnCheckedChanged="Image1_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton id="Image2" Text="Image 2" GroupName="Images" runat="server" OnCheckedChanged="Image2_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton id="Image3" Text="Image 3" GroupName="Images" runat="server" OnCheckedChanged="Image3_CheckedChanged" AutoPostBack="true"/>
                        </div>
                </div>
        
            <div class="BonusDiv" style="background-image: url('Resources/bonusdivfiller.png')";>
                <div></div></div>
        
            <div class="Description">
                <div><asp:TextBox ID="Description" CssClass="Description" runat="server" style="resize:none" TextMode="MultiLine" Rows="10"></asp:TextBox></div></div>
      </div>
      <div class="flex-grid-thirds">
        <asp:Button CssClass="col1" runat="server" OnClick="Change" Text="Save" />
        
        <asp:Button CssClass="col2" runat="server" OnClick="Return" Text="Return" />
        <asp:Button runat="server" OnClick="Delete" CssClass="col3" Text="Delete"  />
      </div>
    </form>
</body>
</html>
