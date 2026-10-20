
<Window x:Class="RyvenTweaker.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="RYVEN TWEAKER"
        Height="760"
        Width="1180"
        MinHeight="620"
        MinWidth="950"
        WindowStartupLocation="CenterScreen"
        Background="#FF09090F"
        Foreground="#FFF5F3FF">

    <Window.Resources>
        <SolidColorBrush x:Key="PanelBrush" Color="#FF141420"/>
        <SolidColorBrush x:Key="AccentBrush" Color="#FF9B5CFF"/>
        <SolidColorBrush x:Key="MutedBrush" Color="#FFAAA5BC"/>
        <SolidColorBrush x:Key="BorderBrushCustom" Color="#FF302640"/>

        <Style TargetType="Button">
            <Setter Property="Background" Value="#FF9B5CFF"/>
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="Padding" Value="14,9"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="FontWeight" Value="SemiBold"/>
            <Setter Property="Cursor" Value="Hand"/>
            <Setter Property="Margin" Value="0,0,0,8"/>
            <Setter Property="HorizontalContentAlignment" Value="Left"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border Background="{TemplateBinding Background}"
                                CornerRadius="7"
                                Padding="{TemplateBinding Padding}">
                            <ContentPresenter
                                HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                VerticalAlignment="Center"/>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>

        <DataTemplate x:Key="TweakCardTemplate">
            <Border Background="#FF191724"
                    BorderBrush="#FF393047"
                    BorderThickness="1"
                    CornerRadius="10"
                    Padding="16"
                    Margin="0,0,0,12">
                <StackPanel>
                    <DockPanel Margin="0,0,0,8">
                        <TextBlock Text="{Binding Risk}"
                                   DockPanel.Dock="Right"
                                   Foreground="#FFCAADFF"
                                   FontSize="11"
                                   FontWeight="SemiBold"
                                   Margin="12,3,0,0"/>

                        <TextBlock Text="{Binding Name}"
                                   FontSize="16"
                                   FontWeight="Bold"
                                   TextWrapping="Wrap"/>
                    </DockPanel>

                    <TextBlock Text="{Binding Description}"
                               Foreground="#FFCCC6D9"
                               TextWrapping="Wrap"
                               Margin="0,0,0,8"/>

                    <TextBlock Text="{Binding ExpectedBenefit,
                                              StringFormat='Expected benefit: {0}'}"
                               Foreground="#FFBDA3FF"
                               TextWrapping="Wrap"
                               Margin="0,0,0,12"/>

                    <Border Background="#FF100F18"
                            CornerRadius="6"
                            Padding="9">
                        <DockPanel>
                            <TextBlock Text="{Binding Category}"
                                       Foreground="#FFAAA5BC"
                                       DockPanel.Dock="Left"/>

                            <TextBlock Text="{Binding Status}"
                                       Foreground="#FFE0D2FF"
                                       FontWeight="SemiBold"
                                       HorizontalAlignment="Right"/>
                        </DockPanel>
                    </Border>
                </StackPanel>
            </Border>
        </DataTemplate>
    </Window.Resources>

    <Grid Margin="24">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <Grid Grid.Row="0" Margin="0,0,0,22">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="Auto"/>
            </Grid.ColumnDefinitions>

            <StackPanel>
                <TextBlock Text="RYVEN"
                           FontSize="32"
                           FontWeight="Bold"
                           Foreground="{StaticResource AccentBrush}"/>
                <TextBlock Text="TWEAKER / GAMING PERFORMANCE"
                           FontSize="12"
                           Foreground="{StaticResource MutedBrush}"/>
            </StackPanel>

            <Border Grid.Column="1"
                    Background="{StaticResource PanelBrush}"
                    BorderBrush="{StaticResource BorderBrushCustom}"
                    BorderThickness="1"
                    CornerRadius="10"
                    Padding="14,10"
                    VerticalAlignment="Center">
                <StackPanel>
                    <TextBlock Text="SYSTEM STATUS"
                               FontSize="10"
                               Foreground="{StaticResource MutedBrush}"/>
                    <TextBlock x:Name="StatusText"
                               Text="READY"
                               FontSize="13"
                               FontWeight="SemiBold"
                               Foreground="{StaticResource AccentBrush}"/>
                </StackPanel>
            </Border>
        </Grid>

        <Border Grid.Row="1"
                Background="{StaticResource PanelBrush}"
                BorderBrush="{StaticResource BorderBrushCustom}"
                BorderThickness="1"
                CornerRadius="12"
                Padding="16"
                Margin="0,0,0,18">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>

                <StackPanel Margin="0,0,8,0">
                    <TextBlock Text="PROCESSOR"
                               Foreground="{StaticResource MutedBrush}"
                               FontSize="10"/>
                    <TextBlock x:Name="CpuText"
                               Text="Not scanned"
                               FontSize="13"
                               FontWeight="SemiBold"
                               TextWrapping="Wrap"
                               Margin="0,6,0,0"/>
                </StackPanel>

                <StackPanel Grid.Column="1" Margin="0,0,8,0">
                    <TextBlock Text="GRAPHICS"
                               Foreground="{StaticResource MutedBrush}"
                               FontSize="10"/>
                    <TextBlock x:Name="GpuText"
                               Text="Not scanned"
                               FontSize="13"
                               FontWeight="SemiBold"
                               TextWrapping="Wrap"
                               Margin="0,6,0,0"/>
                </StackPanel>

                <StackPanel Grid.Column="2" Margin="0,0,8,0">
                    <TextBlock Text="MEMORY"
                               Foreground="{StaticResource MutedBrush}"
                               FontSize="10"/>
                    <TextBlock x:Name="RamText"
                               Text="Not scanned"
                               FontSize="13"
                               FontWeight="SemiBold"
                               Margin="0,6,0,0"/>
                </StackPanel>

                <Button Grid.Column="3"
                        Content="SCAN PC"
                        VerticalAlignment="Center"
                        Margin="8,0,0,0"
                        Click="ScanButton_Click"/>
            </Grid>
        </Border>

        <Grid Grid.Row="2">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="190"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>

            <Border Background="{StaticResource PanelBrush}"
                    BorderBrush="{StaticResource BorderBrushCustom}"
                    BorderThickness="1"
                    CornerRadius="12"
                    Padding="12"
                    Margin="0,0,16,0">
                <ScrollViewer VerticalScrollBarVisibility="Auto">
                    <StackPanel>
                        <TextBlock Text="OPTIMIZATION"
                                   FontSize="11"
                                   Foreground="{StaticResource MutedBrush}"
                                   Margin="4,4,4,14"/>

                        <Button Content="Overview"
                                Click="OverviewButton_Click"/>
                        <Button Content="Windows"
                                Click="WindowsButton_Click"/>
                        <Button Content="CPU &amp; RAM"
                                Click="HardwareButton_Click"/>
                        <Button Content="GPU"
                                Click="GpuButton_Click"/>
                        <Button Content="Network"
                                Click="NetworkButton_Click"/>
                        <Button Content="Input &amp; Mouse"
                                Click="InputButton_Click"/>
                        <Button Content="Game Profiles"
                                Click="GamesButton_Click"/>
                    </StackPanel>
                </ScrollViewer>
            </Border>

            <Border Grid.Column="1"
                    Background="{StaticResource PanelBrush}"
                    BorderBrush="{StaticResource BorderBrushCustom}"
                    BorderThickness="1"
                    CornerRadius="12"
                    Padding="18">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="*"/>
                    </Grid.RowDefinitions>

                    <StackPanel>
                        <TextBlock x:Name="PageTitle"
                                   Text="Performance Center"
                                   FontSize="23"
                                   FontWeight="Bold"/>

                        <TextBlock x:Name="PageDescription"
                                   Text="Browse your optimization catalog."
                                   Foreground="{StaticResource MutedBrush}"
                                   TextWrapping="Wrap"
                                   Margin="0,6,0,0"/>
                    </StackPanel>

                    <TextBox x:Name="SearchBox"
                             Grid.Row="1"
                             Height="38"
                             Margin="0,16,0,14"
                             Padding="10,8"
                             Background="#FF0D0D15"
                             Foreground="White"
                             BorderBrush="#FF40334F"
                             CaretBrush="White"
                             ToolTip="Search tweaks by name, category, or description"
                             TextChanged="SearchBox_TextChanged"
                             VerticalContentAlignment="Center"/>

                    <Grid Grid.Row="2">
                        <TextBlock x:Name="EmptyStateText"
                                   Text="No matching tweaks."
                                   Foreground="{StaticResource MutedBrush}"
                                   HorizontalAlignment="Center"
                                   VerticalAlignment="Center"
                                   TextWrapping="Wrap"
                                   Margin="20"/>

                        <ScrollViewer VerticalScrollBarVisibility="Auto">
                            <ItemsControl x:Name="TweakList"
                                          ItemTemplate="{StaticResource TweakCardTemplate}"/>
                        </ScrollViewer>
                    </Grid>
                </Grid>
            </Border>
        </Grid>

        <Grid Grid.Row="3" Margin="0,14,0,0">
            <TextBlock Text="RYVEN TWEAKER • GAMING PERFORMANCE"
                       Foreground="{StaticResource MutedBrush}"
                       FontSize="10"
                       VerticalAlignment="Center"/>

            <TextBlock Text="System changes require careful testing"
                       Foreground="{StaticResource MutedBrush}"
                       FontSize="10"
                       HorizontalAlignment="Right"
                       VerticalAlignment="Center"/>
        </Grid>
    </Grid>
</Window>
