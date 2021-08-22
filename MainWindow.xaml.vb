Class MainWindow
    Public Property MdiParent As winPrincipal
    Function ConsultarCarrera() As List(Of clsCarrera)
        dtgCarreras.Items.Clear()
        Dim vLista As List(Of clsCarrera) = New List(Of clsCarrera)

        Dim blc As blCarrera = New blCarrera()

        vLista = blc.ConsultarCarrerasBL()

        For Each item In vLista

            dtgCarreras.Items.Add(item)

        Next

        Return vLista

    End Function


    Public Sub RegistrarCarrera()

        Dim vCarreraRegistrar As clsCarrera = New clsCarrera()
        Dim blc As blCarrera = New blCarrera()
        Dim vError As String = Nothing

        vCarreraRegistrar.nom_c_prop = txtNombreCarrera.Text
        vCarreraRegistrar.dura_c_prop = Convert.ToDouble(txtDuracionCarrera.Text)

        blc.RegistrarCarreraBL(vCarreraRegistrar, vError)

        If vError Is Nothing Then
            ConsultarCarrera()
            txtDuracionCarrera.Text = Nothing
            txtNombreCarrera.Text = Nothing
            txbId.Text = Nothing
            MessageBox.Show("Carrera Registrada correctamente")
        Else
            MessageBox.Show("No se pudo registrar la carrera. Desc error: " + vError)
        End If

    End Sub


    Public Sub ModificarCarrera()

        Dim vCarreraModificar As clsCarrera = New clsCarrera()
        Dim blc As blCarrera = New blCarrera()
        Dim vError As String = Nothing

        vCarreraModificar.nom_c_prop = txtNombreCarrera.Text
        vCarreraModificar.dura_c_prop = Convert.ToDouble(txtDuracionCarrera.Text)
        vCarreraModificar.clave_c_prop = Convert.ToInt32(txbId.Text)

        blc.ModificarCarreraBL(vCarreraModificar, vError)

        If vError Is Nothing Then
            ConsultarCarrera()
            txtDuracionCarrera.Text = Nothing
            txtNombreCarrera.Text = Nothing
            txbId.Text = Nothing
            MessageBox.Show("Carrera Modificada correctamente")
        Else
            MessageBox.Show("No se pudo modificar la carrera. Desc error: " + vError)
        End If

    End Sub


    Public Sub EliminarCarrera()

        Dim vCarreraEliminar As clsCarrera = New clsCarrera()
        Dim blc As blCarrera = New blCarrera()
        Dim vError As String = Nothing

        vCarreraEliminar.clave_c_prop = Convert.ToInt32(txbId.Text)

        blc.EliminarCarreraBL(vCarreraEliminar, vError)

        If vError Is Nothing Then
            ConsultarCarrera()
            txtDuracionCarrera.Text = Nothing
            txtNombreCarrera.Text = Nothing
            txbId.Text = Nothing
            MessageBox.Show("Carrera Eliminada correctamente")
        Else
            MessageBox.Show("No se pudo eliminar la carrera. Desc error: " + vError)
        End If

    End Sub


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        ConsultarCarrera()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        RegistrarCarrera()
    End Sub

    Private Sub dtgCarreras_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgCarreras.SelectionChanged
        If dtgCarreras.SelectedItem IsNot Nothing Then
            Dim vCarreraSeleccionada As clsCarrera = TryCast(dtgCarreras.SelectedItem, clsCarrera)


            txbId.Text = vCarreraSeleccionada.clave_c_prop
            txtNombreCarrera.Text = vCarreraSeleccionada.nom_c_prop
            txtDuracionCarrera.Text = vCarreraSeleccionada.dura_c_prop.ToString()

        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As RoutedEventArgs) Handles btnModificar.Click
        ModificarCarrera()
    End Sub

    Private Sub btnEliminarCarrera_Click(sender As Object, e As RoutedEventArgs)
        EliminarCarrera()
    End Sub

End Class
