Public Class winPrincipal

    Private Sub btn_manten_carrera_Click(sender As Object, e As RoutedEventArgs) Handles btn_manten_carrera.Click

        Dim form As New MainWindow
        form.MdiParent = Me
        form.Show()
        form.ConsultarCarrera()

    End Sub

    Private Sub btn_manten_materia_Click(sender As Object, e As RoutedEventArgs) Handles btn_manten_materia.Click

        Dim form1 As New winMateria
        form1.MdiParent = Me
        form1.Show()
        form1.ConsultarMateria()

    End Sub

    Private Sub btn_mantenimiento_alumno_Click(sender As Object, e As RoutedEventArgs) Handles btn_mantenimiento_alumno.Click

        Dim form As New winEstudiante
        form.MdiParent = Me
        form.Show()
        form.ConsultarEstudiante()

    End Sub

    Private Sub btn_manten_profesor_Click(sender As Object, e As RoutedEventArgs) Handles btn_manten_profesor.Click

        Dim form As New winProfesor
        form.MdiParent = Me
        form.Show()
        form.ConsultarProfesor()

    End Sub
End Class
