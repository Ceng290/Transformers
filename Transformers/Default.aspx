<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Transformers.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transformers</title>

    <link href="css/StyleSheet1.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div id="page-wrap">
        <div>
            <h1>Enter the Autobots teams:</h1>
            <table>
                <tr>
                    <td>
                      <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="id"                            
                            onrowcommand="GridView1_RowCommand"                            
                            BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"   
                            CellSpacing="1" GridLines="None">

                        <Columns>
                        <asp:TemplateField HeaderText="Name" ControlStyle-Width="150px">  
                            <ItemTemplate>  
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("name") %>'></asp:Label>  
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="i_name" width="240px" runat="server" Enabled="True" />                                
                            </FooterTemplate>  
                        </asp:TemplateField>
                              
                        <asp:TemplateField HeaderText="Autobot/Decepticon">  
                            <ItemTemplate>  
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("AutobotDecepticon") %>'></asp:Label>  
                            </ItemTemplate>  
                            <FooterTemplate>
                                <asp:DropDownList ID="i_AutobotDecepticon" runat="server">  
                                    <asp:ListItem>A</asp:ListItem>  
                                    <asp:ListItem>D</asp:ListItem>                                      
                                </asp:DropDownList>  
                            </FooterTemplate>  
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Strength">  
                            <ItemTemplate>  
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("strength") %>'></asp:Label>  
                            </ItemTemplate>  
                            <FooterTemplate>
                                <asp:DropDownList ID="i_strength" runat="server">  
                                    <asp:ListItem>0</asp:ListItem>  
                                    <asp:ListItem>1</asp:ListItem>  
                                    <asp:ListItem>2</asp:ListItem>  
                                    <asp:ListItem>3</asp:ListItem>  
                                    <asp:ListItem>4</asp:ListItem>  
                                    <asp:ListItem>5</asp:ListItem>  
                                    <asp:ListItem>6</asp:ListItem>  
                                    <asp:ListItem>7</asp:ListItem>  
                                    <asp:ListItem>8</asp:ListItem>  
                                    <asp:ListItem>9</asp:ListItem>  
                                    <asp:ListItem>10</asp:ListItem>  
                                </asp:DropDownList>  
                            </FooterTemplate>  
                        </asp:TemplateField>
                             
                        <asp:TemplateField HeaderText="Intelligence">  
                            <ItemTemplate>  
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("intelligence") %>'></asp:Label>  
                            </ItemTemplate>  
                            <FooterTemplate>
                                <asp:DropDownList ID="i_intelligence" runat="server">  
                                    <asp:ListItem>0</asp:ListItem>  
                                    <asp:ListItem>1</asp:ListItem>  
                                    <asp:ListItem>2</asp:ListItem>  
                                    <asp:ListItem>3</asp:ListItem>  
                                    <asp:ListItem>4</asp:ListItem>  
                                    <asp:ListItem>5</asp:ListItem>  
                                    <asp:ListItem>6</asp:ListItem>  
                                    <asp:ListItem>7</asp:ListItem>  
                                    <asp:ListItem>8</asp:ListItem>  
                                    <asp:ListItem>9</asp:ListItem>  
                                    <asp:ListItem>10</asp:ListItem>  
                                </asp:DropDownList>  
                            </FooterTemplate>  
                        </asp:TemplateField>
                             
                        <asp:TemplateField HeaderText="Speed">  
                            <ItemTemplate>  
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("speed") %>'></asp:Label>  
                            </ItemTemplate>  
                            <FooterTemplate>
                                <asp:DropDownList ID="i_speed" runat="server">  
                                    <asp:ListItem>0</asp:ListItem>  
                                    <asp:ListItem>1</asp:ListItem>  
                                    <asp:ListItem>2</asp:ListItem>  
                                    <asp:ListItem>3</asp:ListItem>  
                                    <asp:ListItem>4</asp:ListItem>  
                                    <asp:ListItem>5</asp:ListItem>  
                                    <asp:ListItem>6</asp:ListItem>  
                                    <asp:ListItem>7</asp:ListItem>  
                                    <asp:ListItem>8</asp:ListItem>  
                                    <asp:ListItem>9</asp:ListItem>  
                                    <asp:ListItem>10</asp:ListItem>  
                                </asp:DropDownList>  
                            </FooterTemplate>    
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Endurance">  
                            <ItemTemplate>  
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("endurance") %>'></asp:Label>  
                            </ItemTemplate>  
                            <FooterTemplate>
                                <asp:DropDownList ID="i_endurance" runat="server">  
                                    <asp:ListItem>0</asp:ListItem>  
                                    <asp:ListItem>1</asp:ListItem>  
                                    <asp:ListItem>2</asp:ListItem>  
                                    <asp:ListItem>3</asp:ListItem>  
                                    <asp:ListItem>4</asp:ListItem>  
                                    <asp:ListItem>5</asp:ListItem>  
                                    <asp:ListItem>6</asp:ListItem>  
                                    <asp:ListItem>7</asp:ListItem>  
                                    <asp:ListItem>8</asp:ListItem>  
                                    <asp:ListItem>9</asp:ListItem>  
                                    <asp:ListItem>10</asp:ListItem>  
                                </asp:DropDownList>  
                            </FooterTemplate>    
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rank">  
                            <ItemTemplate>  
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("rank") %>'></asp:Label>  
                            </ItemTemplate>  
                            <FooterTemplate>
                                <asp:DropDownList ID="i_rank" runat="server">  
                                    <asp:ListItem>0</asp:ListItem>  
                                    <asp:ListItem>1</asp:ListItem>  
                                    <asp:ListItem>2</asp:ListItem>  
                                    <asp:ListItem>3</asp:ListItem>  
                                    <asp:ListItem>4</asp:ListItem>  
                                    <asp:ListItem>5</asp:ListItem>  
                                    <asp:ListItem>6</asp:ListItem>  
                                    <asp:ListItem>7</asp:ListItem>  
                                    <asp:ListItem>8</asp:ListItem>  
                                    <asp:ListItem>9</asp:ListItem>  
                                    <asp:ListItem>10</asp:ListItem>  
                                </asp:DropDownList>  
                            </FooterTemplate>    
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Courage">  
                            <ItemTemplate>  
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("courage") %>'></asp:Label>  
                            </ItemTemplate>  
                            <FooterTemplate>
                                <asp:DropDownList ID="i_courage" runat="server">  
                                    <asp:ListItem>0</asp:ListItem>  
                                    <asp:ListItem>1</asp:ListItem>  
                                    <asp:ListItem>2</asp:ListItem>  
                                    <asp:ListItem>3</asp:ListItem>  
                                    <asp:ListItem>4</asp:ListItem>  
                                    <asp:ListItem>5</asp:ListItem>  
                                    <asp:ListItem>6</asp:ListItem>  
                                    <asp:ListItem>7</asp:ListItem>  
                                    <asp:ListItem>8</asp:ListItem>  
                                    <asp:ListItem>9</asp:ListItem>  
                                    <asp:ListItem>10</asp:ListItem>  
                                </asp:DropDownList>  
                            </FooterTemplate>    
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Firepower">  
                            <ItemTemplate>  
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("firepower") %>'></asp:Label>  
                            </ItemTemplate>  
                            <FooterTemplate>
                                <asp:DropDownList ID="i_firepower" runat="server">  
                                    <asp:ListItem>0</asp:ListItem>  
                                    <asp:ListItem>1</asp:ListItem>  
                                    <asp:ListItem>2</asp:ListItem>  
                                    <asp:ListItem>3</asp:ListItem>  
                                    <asp:ListItem>4</asp:ListItem>  
                                    <asp:ListItem>5</asp:ListItem>  
                                    <asp:ListItem>6</asp:ListItem>  
                                    <asp:ListItem>7</asp:ListItem>  
                                    <asp:ListItem>8</asp:ListItem>  
                                    <asp:ListItem>9</asp:ListItem>  
                                    <asp:ListItem>10</asp:ListItem>  
                                </asp:DropDownList>  
                            </FooterTemplate>    
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Skill">  
                            <ItemTemplate>  
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("skill") %>'></asp:Label>  
                            </ItemTemplate>  
                            <FooterTemplate>
                                <asp:DropDownList ID="i_skill" runat="server">  
                                    <asp:ListItem>0</asp:ListItem>  
                                    <asp:ListItem>1</asp:ListItem>  
                                    <asp:ListItem>2</asp:ListItem>  
                                    <asp:ListItem>3</asp:ListItem>  
                                    <asp:ListItem>4</asp:ListItem>  
                                    <asp:ListItem>5</asp:ListItem>  
                                    <asp:ListItem>6</asp:ListItem>  
                                    <asp:ListItem>7</asp:ListItem>  
                                    <asp:ListItem>8</asp:ListItem>  
                                    <asp:ListItem>9</asp:ListItem>  
                                    <asp:ListItem>10</asp:ListItem>  
                                </asp:DropDownList>  
                            </FooterTemplate>    
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Overall Rating">  
                            <ItemTemplate>  
                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("overallRating") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:Button ID="ButtonAdd" runat="server" CommandName="AddNew"  Text="Add Autobot" ValidationGroup="validaiton" />
                            </FooterTemplate>
                        </asp:TemplateField> 

                        </Columns>  
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />  
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />  
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />  
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />  
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />  
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />  
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />  
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />  
                        <SortedDescendingHeaderStyle BackColor="#33276A" />  
                        </asp:GridView> 
                      </div>
                      <div>
                        <br />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                      </div>
                    </td>
                </tr>
            </table>                        
        </div>    
        <br />
        <div>
            <asp:Button ID="btn_StartBattle" runat="server" Text="Start The Battle" OnClick="btn_StartBattle_Click" />
        </div>        
        <br />
        <div id="specialRules" runat="server" visible="false">
            Game Over -- All competitors have been destroyed!!
        </div>

        <div id="basicRules" runat="server" visible="true">
          <div>
              <h3>Results</h3>
          </div>
          <br/>

          <%--*******************************************************************************************************************--%>
          <%--The Autobots Win and Decepticons have more team members --%>
          <%--*******************************************************************************************************************--%>
          <div id="AutobotsWin" runat="server" visible="false">
            <div id="NumBattles" runat="server">
              <asp:Label ID="lblNumBattles" runat="server"></asp:Label><asp:Label ID="lblBattles" runat="server"></asp:Label>
            </div>
            <div id="AutobotWinningTeam" runat="server">
              Winning Teams (Autobots):<asp:Label ID="lbl_AutobotWinners" runat="server"></asp:Label>
            </div>         
            <div id="DecepticonSurvivors" runat="server" visible="false">
              Survivors from the losing team (Decepticons):<asp:Label ID="lbl_DecepticonSurvivors" runat="server"></asp:Label>
            </div>
          </div>
          <br />

          <%--*******************************************************************************************************************--%>
          <%--The Decepticons Win and Autobots have more team members--%>
          <%--*******************************************************************************************************************--%>
          <div id="decepticonsWin" runat="server" visible="false">
            <div id="numberBattles" runat="server">
              <asp:Label ID="lblnumberBattles" runat="server"></asp:Label><asp:Label ID="lbl_Battles" runat="server"></asp:Label>
            </div>
            <div id="DecepticonWinningTeam" runat="server">
                Winning Teams (Decepticons):<asp:Label ID="lbl_DecepticonWinners" runat="server"></asp:Label>
            </div>            
            <div id="AutobotSurvivors" runat="server" visible="false">
                Survivors from the losing team (Autobots):<asp:Label ID="lbl_AutobotSurvivors" runat="server"></asp:Label>
            </div>
          </div>
          <br />
          <%--*******************************************************************************************************************--%>
          <%--The Tie Win and Autobots have more team members or Decepticons have more team members--%>
          <%--*******************************************************************************************************************--%>
          <div id="tie" runat="server" visible="false">
            <div id="number_battles" runat="server">
                <asp:Label ID="lbl_numberBattles" runat="server"></asp:Label><asp:Label ID="lblnumberBattle" runat="server"></asp:Label>
            </div>
            <div id="Autobot_WinningTeam" runat="server">
              Winning Teams Autobots:<asp:Label ID="lbl_Autobots_Winners" runat="server"></asp:Label>
            </div>         
            <div id="Autobot_Survivors" runat="server" visible="false">
              Survivors from the Autobots:<asp:Label ID="lbl_Autobots_Survivors" runat="server"></asp:Label>
            </div>

            <div id="Decepticon_WinningTeam" runat="server">
              Winning Teams Decepticons:<asp:Label ID="lbl_Decepticons_Winners" runat="server"></asp:Label>
            </div>
            <div id="Decepticon_Survivors" runat="server" visible="false">
              Survivors from the Decepticons:<asp:Label ID="lbl_Decepticons_Survivors" runat="server"></asp:Label>
            </div>
          </div>
        </div>
        <br />
        <div id="tie2" runat="server" visible="false">           
          <div id="Div3" runat="server">
            Destroyed Transformers:<asp:Label ID="lblDestroyedTransformers" runat="server"></asp:Label>
          </div>                   
        </div>
        <br />
        <div>
            <asp:Button ID="btn_StartNewGame" runat="server" Text="Start A New Battle" OnClick="btn_StartNewGame_Click" />
        </div>        
        <br />
    </div>
    </form>
</body>
</html>
