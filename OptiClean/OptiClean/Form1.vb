Imports System.IO
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Management
Imports System.Security.AccessControl

Public Class OptiClean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label3.Hide()
        Label4.Hide()

        Dim path As String = "C:\Windows\Temp"

        For Each deleteFile In Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                File.Delete(deleteFile)
            Catch ex As Exception

            End Try
        Next
        For Each deleteFolder In Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                Directory.Delete(deleteFolder)
            Catch ex As Exception

            End Try
        Next

        path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Temp"

        For Each deleteFile In Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                File.Delete(deleteFile)
            Catch ex As Exception

            End Try
        Next
        For Each deleteFolder In Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                Directory.Delete(deleteFolder)
            Catch ex As Exception

            End Try
        Next

        path = "C:\Windows\Prefetch"

        For Each deleteFile In Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                File.Delete(deleteFile)
            Catch ex As Exception

            End Try
        Next
        For Each deleteFolder In Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                Directory.Delete(deleteFolder)
            Catch ex As Exception

            End Try
        Next

        Try
            Dim IsSuccess As UInteger = SHEmptyRecycleBin(IntPtr.Zero, Nothing, RecycleFlags.SHRB_NOCONFIRMATION)
        Catch ex As Exception

        End Try

        path = "C:\Windows\Downloaded Program Files"

        For Each deleteFile In Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                File.Delete(deleteFile)
            Catch ex As Exception

            End Try
        Next
        For Each deleteFolder In Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                Directory.Delete(deleteFolder)
            Catch ex As Exception

            End Try
        Next

        path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Microsoft\Windows\INetCache\IE"

        For Each deleteFile In Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                File.Delete(deleteFile)
            Catch ex As Exception

            End Try
        Next
        For Each deleteFolder In Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                Directory.Delete(deleteFolder)
            Catch ex As Exception

            End Try
        Next

        path = "C:\Windows\CbsTemp"

        For Each deleteFile In Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                File.Delete(deleteFile)
            Catch ex As Exception

            End Try
        Next
        For Each deleteFolder In Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                Directory.Delete(deleteFolder)
            Catch ex As Exception

            End Try
        Next

        path = "C:\Windows\SoftwareDistribution\Download"

        For Each deleteFile In Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                File.Delete(deleteFile)
            Catch ex As Exception

            End Try
        Next
        For Each deleteFolder In Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly)
            Try
                Directory.Delete(deleteFolder)
            Catch ex As Exception

            End Try
        Next
        Label4.Show()
    End Sub

    Private Enum RecycleFlags As UInteger
        SHRB_NOCONFIRMATION = &H1
        SHRB_NOPROGRESSUI = &H2
        SHRB_NOSOUND = &H4
    End Enum

    <DllImport("Shell32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SHEmptyRecycleBin(ByVal hwnd As IntPtr, ByVal pszRootPath As String, ByVal dwFlags As RecycleFlags) As UInteger
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label4.Hide()
        Label3.Hide()
        Dim process As New Process()
        Dim processInfo As New ProcessStartInfo()
        processInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        processInfo.Verb = "runas"
        processInfo.FileName = "powershell.exe"
        processInfo.Arguments = "/C Optimize-Volume -DriveLetter C -ReTrim -Verbose"
        process.StartInfo = processInfo
        process.Start()
        Label3.Show()
    End Sub

    Private Sub OptiClean_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Label4.Hide()
        Label3.Hide()
    End Sub
End Class
