Public Class winEstudiante

    'Permite llamar a otras ventanas de la solucion
    Public Property MdiParent As winPrincipal

    'Funcion para consultar mi lista de estudiantes desde clsEstudiante
    Function ConsultarEstudiante() As List(Of clsEstudiante)
        dtgEstudiante.Items.Clear()
        Dim vLista As List(Of clsEstudiante) = New List(Of clsEstudiante)

        Dim bm As blEstudiante = New blEstudiante()

        vLista = bm.ConsultarEstudianteBL()

        For Each item In vLista

            dtgEstudiante.Items.Add(item)

        Next

        Return vLista

    End Function

    'Metodo para registrar estudiantes con los valores ingresados
    Public Sub RegistrarEstudiante()

        Dim vEstudianteRegistrar As clsEstudiante = New clsEstudiante()
        Dim blc As blEstudiante = New blEstudiante()
        Dim vError As String = Nothing

        vEstudianteRegistrar.prop_nom_alu = txtNombreEstudiante.Text
        vEstudianteRegistrar.prop_edad_alu = Convert.ToDouble(txtEdad.Text)
        vEstudianteRegistrar.prop_sem_alu = Convert.ToDouble(txtSemestre.Text)
        'vEstudianteRegistrar.prop_gen_alu = txtGenero.Text
        vEstudianteRegistrar.prop_gen_alu = cmbGenero.Text
        vEstudianteRegistrar.prop_clave_c1 = Convert.ToDouble(txtClave_c.Text)

        blc.RegistrarEstudianteBL(vEstudianteRegistrar, vError)

        If vError Is Nothing Then
            ConsultarEstudiante()
            txbIdEstudiente.Text = Nothing
            txtNombreEstudiante.Text = Nothing
            txtEdad.Text = Nothing
            txtSemestre.Text = Nothing
            txtGenero.Text = Nothing
            txtClave_c.Text = Nothing
            MessageBox.Show("Estudiante registrado correctamente")
        Else
            MessageBox.Show("No se pudo registrar el estudiante. Desc error: " + vError)
        End If

    End Sub

    'Metodo para modificar estudiantes con los valores ingresados
    Public Sub ModificarEstudiante()

        Dim vEstudianteModificar As clsEstudiante = New clsEstudiante()
        Dim blc As blEstudiante = New blEstudiante()
        Dim vError As String = Nothing

        vEstudianteModificar.prop_mat_alu = Convert.ToInt32(txbIdEstudiente.Text)
        vEstudianteModificar.prop_nom_alu = txtNombreEstudiante.Text
        vEstudianteModificar.prop_edad_alu = Convert.ToDouble(txtEdad.Text)
        vEstudianteModificar.prop_sem_alu = Convert.ToDouble(txtSemestre.Text)
        vEstudianteModificar.prop_gen_alu = cmbGenero.Text
        vEstudianteModificar.prop_clave_c1 = Convert.ToDouble(txtClave_c.Text)

        blc.ModificarEstudianteBL(vEstudianteModificar, vError)

        If vError Is Nothing Then
            ConsultarEstudiante()
            txbIdEstudiente.Text = Nothing
            txtNombreEstudiante.Text = Nothing
            txtEdad.Text = Nothing
            txtSemestre.Text = Nothing
            txtGenero.Text = Nothing
            txtClave_c.Text = Nothing
            MessageBox.Show("Estudiante modificado correctamente")
        Else
            MessageBox.Show("No se pudo modificar el estudiante. Desc error: " + vError)
        End If

    End Sub

    'Metodo para eliminar el estudiante seleccionado
    Public Sub EliminarEstudiante()

        Dim vEstudianteEliminar As clsEstudiante = New clsEstudiante()
        Dim blc As blEstudiante = New blEstudiante()
        Dim vError As String = Nothing

        vEstudianteEliminar.prop_mat_alu = Convert.ToInt32(txbIdEstudiente.Text)

        blc.EliminarEstudianteBL(vEstudianteEliminar, vError)

        If vError Is Nothing Then
            ConsultarEstudiante()
            txbIdEstudiente.Text = Nothing
            txtNombreEstudiante.Text = Nothing
            txtEdad.Text = Nothing
            txtSemestre.Text = Nothing
            txtGenero.Text = Nothing
            txtClave_c.Text = Nothing
            MessageBox.Show("Estudiante eliminado correctamente")
        Else
            MessageBox.Show("No se pudo eliminar el estudiante. Desc error: " + vError)
        End If

    End Sub

    'Evento del boton para llamar al metodo de eliminar
    Private Sub btnEliminarEstudiante_Click(sender As Object, e As RoutedEventArgs)
        EliminarEstudiante()
    End Sub

    'Evento del DataGrid para seleccionar la fila
    Private Sub dtgEstudiante_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgEstudiante.SelectionChanged
        If dtgEstudiante.SelectedItem IsNot Nothing Then
            Dim vEstudianteSeleccionado As clsEstudiante = TryCast(dtgEstudiante.SelectedItem, clsEstudiante)

            txbIdEstudiente.Text = vEstudianteSeleccionado.prop_mat_alu.ToString()
            txtNombreEstudiante.Text = vEstudianteSeleccionado.prop_nom_alu
            txtEdad.Text = vEstudianteSeleccionado.prop_edad_alu.ToString()
            txtGenero.Text = vEstudianteSeleccionado.prop_gen_alu
            txtSemestre.Text = vEstudianteSeleccionado.prop_sem_alu.ToString()
            txtClave_c.Text = vEstudianteSeleccionado.prop_clave_c1.ToString()

        End If
    End Sub

    'Evento del boton para llamar al metodo de registrar
    Private Sub btnGuardarEstudiante_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarEstudiante.Click
        RegistrarEstudiante()
    End Sub

    'Evento del boton para llamar al metodo de modificar
    Private Sub btnModificarEstudiante_Click(sender As Object, e As RoutedEventArgs) Handles btnModificarEstudiante.Click
        ModificarEstudiante()
    End Sub

End Class
