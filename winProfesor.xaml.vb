Public Class winProfesor

    'Permite llamar a otras ventanas de la solucion
    Public Property MdiParent As winPrincipal

    'Funcion que retorna la lista de profesores desde la clase clsProfesor
    Function ConsultarProfesor() As List(Of clsProfesor)
        dtgProfesor.Items.Clear()
        Dim vLista As List(Of clsProfesor) = New List(Of clsProfesor)

        ' Dim bm As clsMateria = New clsMateria()
        Dim bm As blProfesor = New blProfesor()

        vLista = bm.ConsultarProfesorBL()

        For Each item In vLista
            dtgProfesor.Items.Add(item)
        Next

        Return vLista

    End Function

    'Metodo para registrar profesores con los valores ingresados
    Public Sub RegistrarProfesor()

        Dim vProfesorRegistrar As clsProfesor = New clsProfesor()
        Dim blc As blProfesor = New blProfesor()
        Dim vError As String = Nothing

        vProfesorRegistrar.prop_nom_p = txtNombreProfesor.Text
        vProfesorRegistrar.prop_tel_p = Convert.ToDouble(txtTelefono.Text)
        vProfesorRegistrar.prop_dir_p = txtDireccion.Text
        'vProfesorRegistrar.prop_hor_p = Convert.ToDateTime(txtHorario.Text)
        vProfesorRegistrar.prop_hor_p = cl_horario.SelectedDate

        blc.RegistrarProfesorBL(vProfesorRegistrar, vError)

        If vError Is Nothing Then
            ConsultarProfesor()
            txbIdProfesor.Text = Nothing
            txtNombreProfesor.Text = Nothing
            txtDireccion.Text = Nothing
            txtTelefono.Text = Nothing
            txtHorario.Text = Nothing

            MessageBox.Show("Profesor Registrado correctamente")
        Else
            MessageBox.Show("No se pudo registrar el profesor. Desc error: " + vError)
        End If

    End Sub

    'Metodo para modificar profesores con los valores ingresados
    Public Sub ModificarProfesor()

        Dim vProfesorModificar As clsProfesor = New clsProfesor()
        Dim blc As blProfesor = New blProfesor()
        Dim vError As String = Nothing

        vProfesorModificar.prop_clave_p = Convert.ToInt32(txbIdProfesor.Text)
        vProfesorModificar.prop_nom_p = txtNombreProfesor.Text
        vProfesorModificar.prop_tel_p = Convert.ToDouble(txtTelefono.Text)
        'vProfesorModificar.prop_hor_p = Convert.ToDateTime(txtHorario.Text)
        vProfesorModificar.prop_hor_p = cl_horario.SelectedDate
        vProfesorModificar.prop_dir_p = txtDireccion.Text

        blc.ModificarProfesorBL(vProfesorModificar, vError)

        If vError Is Nothing Then
            ConsultarProfesor()
            txbIdProfesor.Text = Nothing
            txtNombreProfesor.Text = Nothing
            txtDireccion.Text = Nothing
            txtTelefono.Text = Nothing
            txtHorario.Text = Nothing

            MessageBox.Show("Profesor Modificado correctamente")
        Else
            MessageBox.Show("No se pudo modificar el profesor. Desc error: " + vError)
        End If

    End Sub

    'Metodo para eliminar profesores con los valores ingresados
    Public Sub EliminarProfesor()

        Dim vProfesorEliminar As clsProfesor = New clsProfesor()
        Dim blc As blProfesor = New blProfesor()
        Dim vError As String = Nothing

        vProfesorEliminar.prop_clave_p = Convert.ToInt32(txbIdProfesor.Text)

        blc.EliminarProfesorBL(vProfesorEliminar, vError)

        If vError Is Nothing Then
            ConsultarProfesor()
            txbIdProfesor.Text = Nothing
            txtNombreProfesor.Text = Nothing
            txtDireccion.Text = Nothing
            txtTelefono.Text = Nothing
            txtHorario.Text = Nothing

            MessageBox.Show("Profesor Eliminado correctamente")
        Else
            MessageBox.Show("No se pudo eliminar el profesor. Desc error: " + vError)
        End If

    End Sub

    'Evento del boton para llamar al metodo de eliminar
    Private Sub btnEliminarProfesor_Click(sender As Object, e As RoutedEventArgs)
        EliminarProfesor()
    End Sub

    'Evento del DataGrid para seleccionar la fila
    Private Sub dtgProfesor_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgProfesor.SelectionChanged

        If dtgProfesor.SelectedItem IsNot Nothing Then
            Dim vProfesorSeleccionado As clsProfesor = TryCast(dtgProfesor.SelectedItem, clsProfesor)

            txbIdProfesor.Text = vProfesorSeleccionado.prop_clave_p.ToString()
            txtNombreProfesor.Text = vProfesorSeleccionado.prop_nom_p
            txtTelefono.Text = vProfesorSeleccionado.prop_tel_p.ToString()
            txtDireccion.Text = vProfesorSeleccionado.prop_dir_p
            txtHorario.Text = vProfesorSeleccionado.prop_hor_p.ToString()

        End If

    End Sub

    'Evento del boton para llamar al metodo de registrar
    Private Sub btnGuardarProfesor_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarProfesor.Click
        RegistrarProfesor()
    End Sub

    'Evento del boton para llamar al metodo de modificar
    Private Sub btnModificarProfesor_Click(sender As Object, e As RoutedEventArgs) Handles btnModificarProfesor.Click
        ModificarProfesor()
    End Sub

End Class
