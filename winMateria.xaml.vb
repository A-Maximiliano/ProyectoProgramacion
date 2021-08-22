Public Class winMateria

    'Permite llamar a otras ventanas de la solucion
    Public Property MdiParent As winPrincipal

    'Funcion para consultar mi lista de estudiantes desde la clase clsMateria
    Function ConsultarMateria() As List(Of clsMateria)
        dtgMaterias.Items.Clear()
        Dim vLista As List(Of clsMateria) = New List(Of clsMateria)

        ' Dim bm As clsMateria = New clsMateria()
        Dim bm As blMateria = New blMateria()

        vLista = bm.ConsultarMateriaBL()

        For Each item In vLista

            dtgMaterias.Items.Add(item)

        Next

        Return vLista

    End Function

    'Metodo para registrar materias con los valores ingresados
    Public Sub RegistrarMateria()

        Dim vMateriaRegistrar As clsMateria = New clsMateria()
        Dim blc As blMateria = New blMateria()
        Dim vError As String = Nothing

        vMateriaRegistrar.prop_nom_m = txtNombreCarrera.Text
        vMateriaRegistrar.prop_creed_m = Convert.ToDouble(txtDuracionCarrera.Text)

        blc.RegistrarMateriaBL(vMateriaRegistrar, vError)

        If vError Is Nothing Then
            ConsultarMateria()
            txtDuracionCarrera.Text = Nothing
            txtNombreCarrera.Text = Nothing
            txbId.Text = Nothing
            MessageBox.Show("Materia Registrada correctamente")
        Else
            MessageBox.Show("No se pudo registrar la materia. Desc error: " + vError)
        End If

    End Sub

    'Metodo para modificar materias con los valores ingresados
    Public Sub ModificarMateria()

        Dim vMateriaModificar As clsMateria = New clsMateria()
        Dim blc As blMateria = New blMateria()
        Dim vError As String = Nothing

        vMateriaModificar.prop_nom_m = txtNombreCarrera.Text
        vMateriaModificar.prop_creed_m = Convert.ToDouble(txtDuracionCarrera.Text)
        vMateriaModificar.prop_clave_m = Convert.ToInt32(txbId.Text)

        blc.ModificarMateriaBL(vMateriaModificar, vError)

        If vError Is Nothing Then
            ConsultarMateria()
            txtDuracionCarrera.Text = Nothing
            txtNombreCarrera.Text = Nothing
            txbId.Text = Nothing
            MessageBox.Show("Materia Modificada correctamente")
        Else
            MessageBox.Show("No se pudo modificar la materia. Desc error: " + vError)
        End If

    End Sub

    'Metodo para eliminar materias con los valores ingresados
    Public Sub EliminarMateria()

        Dim vMateriaEliminar As clsMateria = New clsMateria()
        Dim blc As blMateria = New blMateria()
        Dim vError As String = Nothing

        vMateriaEliminar.prop_clave_m = Convert.ToInt32(txbId.Text)

        blc.EliminarMateriaBL(vMateriaEliminar, vError)

        If vError Is Nothing Then
            ConsultarMateria()
            txtDuracionCarrera.Text = Nothing
            txtNombreCarrera.Text = Nothing
            txbId.Text = Nothing
            MessageBox.Show("Materia Eliminada correctamente")
        Else
            MessageBox.Show("No se pudo eliminar la materia. Desc error: " + vError)
        End If

    End Sub

    'Evento del boton para llamar al metodo de eliminar
    Private Sub btnEliminarMateria_Click(sender As Object, e As RoutedEventArgs)
        EliminarMateria()
    End Sub

    'Evento del boton para llamar al metodo de registrar
    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        RegistrarMateria()
    End Sub

    'Evento del boton para llamar al metodo de modificar
    Private Sub btnModificar_Click(sender As Object, e As RoutedEventArgs) Handles btnModificar.Click
        ModificarMateria()
    End Sub

    'Evento del DataGrid para seleccionar la fila
    Private Sub dtgMaterias_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgMaterias.SelectionChanged
        If dtgMaterias.SelectedItem IsNot Nothing Then
            Dim vMateriaSeleccionada As clsMateria = TryCast(dtgMaterias.SelectedItem, clsMateria)

            txbId.Text = vMateriaSeleccionada.prop_clave_m
            txtNombreCarrera.Text = vMateriaSeleccionada.prop_nom_m
            txtDuracionCarrera.Text = vMateriaSeleccionada.prop_creed_m.ToString()

        End If
    End Sub

End Class
