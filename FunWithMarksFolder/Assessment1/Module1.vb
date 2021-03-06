﻿Module Module1
    

    Class Booking
        Public BName As String
        Public BAddress As String
        Public BNumber As String
        Public BDate As Date
        Public BTime As Date
        Public BComplete As Boolean
    End Class

    Dim Bookings As New List(Of Booking)

    Class Option1
        Public foreGroundColor As ConsoleColor = ConsoleColor.Gray
        Public backGroundColor As ConsoleColor = ConsoleColor.Black
        Public forecolorselect As String
        Public colorselect As String
    End Class

    Dim Op1 As New Option1

    Class Profiles
        Public CName As String
        Public COwner As String
        Public CNumber As Integer
        Public CAddress As String
        Public Rate As Single
        Public CompleteHours As Integer
    End Class

    Dim Pro1 As New Profiles

    'Finished
    Sub Loading()

        LoadOptions()

        Console.BackgroundColor = Op1.backGroundColor
        Console.ForegroundColor = Op1.foreGroundColor
        Console.Clear()

        Console.SetCursorPosition(35, 5)
        Console.Write("Loading")
        Threading.Thread.Sleep(500)
        Console.Write(".")
        Threading.Thread.Sleep(500)
        Console.Write(".")
        Threading.Thread.Sleep(500)
        Console.Write(".")
        Threading.Thread.Sleep(500)
        Console.Clear()

    End Sub

    'Finished
    Function GetBookings(complete As Boolean)




        Dim index As Integer = 0

        Console.WriteLine("Here's the Bookings currently in the program")
        Console.WriteLine()
        'Format a writeline into columns
        ' {0,-5} = The First column, is the ID, has 5 spaces
        ' {1,-20} = The Second column, is the Client's Name, has 20 spaces
        ' {2,-20} = The Third column, is the Booking Date, has 25 spaces
        ' {3,-20} = The Fourth column, is the Booking time, has 20 spaces
        Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", "ID", "Client's Name", "Date", "Time")

        Console.WriteLine("============================================================")

        'Ask them for the Booking they want
        For i = 0 To Bookings.Count - 1

            If Bookings(i).BComplete = complete Then

                Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", i, Bookings(i).BName, Bookings(i).BDate.ToShortDateString, Bookings(i).BTime.ToShortTimeString, Bookings(i).BTime)

            End If

        Next

        Console.Write("Enter the index of the Booking: ")
        index = Console.ReadLine()

        Return index

    End Function

    'Finished
    Sub Startup()

        'Startup
        Console.SetCursorPosition(23, 0)
        Console.WriteLine("Welcome to Fun With Lawns v0.1")
        Console.SetCursorPosition(18, 1)
        Console.WriteLine("Your all in one lawn management system.")
        Console.SetCursorPosition(25, 4)
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)

    End Sub

    'Finished
    Sub ProfileSetup()

        Console.Clear()

        'Tells user of no data
        Console.Clear()
        Console.WriteLine("No company information has been found, We'll set up a profile before we begin.")
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)

        'Setting Up the profile
        Console.WriteLine("Here you need to enter the details for your new company profile.")
        Console.WriteLine()
        Console.Write("Company Name: ")
        Pro1.CName = Console.ReadLine
        Console.Write("Company Owner's Name: ")
        Pro1.COwner = Console.ReadLine
        Console.Write("Company Contact number: ")
        Pro1.CNumber = Console.ReadLine
        Console.Write("Company Address: ")
        Pro1.CAddress = Console.ReadLine
        Console.Write("Company Hourly Rate: ")
        Pro1.Rate = Console.ReadLine
        Console.WriteLine()
        Console.WriteLine("Setup is Complete!")

    End Sub

    'Finished
    Sub Menu()



        Dim selection As Char

        Do

            'Save company data
            SaveCompany()

            Dim Pay As Double = Pro1.Rate * Pro1.CompleteHours

            'Draw up the menu
            Console.Clear()
            Console.WriteLine("======================================================")
            Console.SetCursorPosition(20, 1)
            Console.WriteLine("Local Clock: " & Now.ToString("H:mm tt - dd/MM/yy") & " |")
            Console.SetCursorPosition(0, 1)
            Console.WriteLine("| Welcome " & Pro1.COwner)
            Console.WriteLine("|----------------------------------------------------|")
            Console.SetCursorPosition(53, 3)
            Console.WriteLine("|")
            Console.SetCursorPosition(0, 3)
            Console.WriteLine("| Total completed hours: " & Pro1.CompleteHours)
            Console.SetCursorPosition(53, 4)
            Console.WriteLine("|")
            Console.SetCursorPosition(0, 4)
            Console.WriteLine("| Total income:         " & FormatCurrency(Pay))
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| Select from one of the following menu options:     |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (A) Add a booking                                  |")
            Console.WriteLine("| (B) View all incomplete bookings                   |")
            Console.WriteLine("| (C) View all complete booking                      |")
            Console.WriteLine("| (D) Check incomplete bookings for next 7 days      |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (E) View incomplete booking details                |")
            Console.WriteLine("| (F) Edit incomplete booking details                |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (G) Remove a booking                               |")
            Console.WriteLine("| (H) Complete a booking                             |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (I) View business card                             |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (K) Options                                        |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (X) Exit                                           |")
            Console.WriteLine("======================================================")


            SaveBookings()
            SaveCompany()
            SaveOptions()

            'Get the selected letter from the user
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper

            Select Case selection
                Case "A"
                    AddBookings()
                Case "B"
                    AllIncomplete()
                Case "C"
                    AllComplete()
                Case "D"
                    SevenDaysIncomplete()
                Case "E"
                    ViewIncomplete()
                Case "F"
                    EditIncomplete()
                Case "G"
                    RemoveBooking()
                Case "H"
                    CompleteBooking()
                Case "I"
                    BusinessCard()
                Case "J"
                    CompanyDetails()
                Case "K"
                    Options()
            End Select

        Loop Until selection = "X"

    End Sub

    'Finished
    Sub AddBookings()

        Dim x As String

        'Gets the booking
        Dim newBooking As New Booking

        'Adds a booking
        Console.Clear()
        Console.WriteLine("Adding a new booking, enter the details below:")
        Console.WriteLine()
        Console.Write("Client's Name: ")
        newBooking.BName = Console.ReadLine
        Console.Write("Client's Address: ")
        newBooking.BAddress = Console.ReadLine
        Console.Write("Client's Phone Number: ")
        newBooking.BNumber = Console.ReadLine
        Console.Write("Date of the booking (dd/mm/yy): ")
        newBooking.BDate = Console.ReadLine
        Console.Write("Time of the booking (hh:mm am/pm): ")
        newBooking.BTime = Console.ReadLine

        Console.Clear()

        'Confirms the booking
        Console.WriteLine("Booking details are as follows:")
        Console.SetCursorPosition(9, 1)
        Console.WriteLine("Name: " & newBooking.BName)
        Console.SetCursorPosition(9, 2)
        Console.WriteLine("Address: " & newBooking.BAddress)
        Console.SetCursorPosition(9, 3)
        Console.WriteLine("Phone number: " & newBooking.BNumber)
        Console.SetCursorPosition(9, 4)
        Console.WriteLine("Date: " & newBooking.BDate)
        Console.SetCursorPosition(9, 5)
        Console.WriteLine("Time: " & newBooking.BTime)
        Console.WriteLine()
        Console.WriteLine("Are these details correct (y/n)?")
        x = Console.ReadKey(True).KeyChar
        newBooking.BComplete = False

        If x = "y" Then

            Bookings.Add(newBooking)
            Console.WriteLine("Booking added!")
            SaveBookings()

        ElseIf x = "n" Then

            Console.WriteLine("Booking cancelled.")

        End If

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)


    End Sub

    'Finished
    Sub AllIncomplete()

        Console.Clear()
        Console.WriteLine("Here's the Bookings currently in the program")
        Console.WriteLine()
        'Format a writeline into columns
        ' {0,-5} = The First column, is the ID, has 5 spaces
        ' {1,-20} = The Second column, is the Client's Name, has 20 spaces
        ' {2,-20} = The Third column, is the Booking Date, has 25 spaces
        ' {3,-20} = The Fourth column, is the Booking time, has 20 spaces
        Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", "ID", "Client's Name", "Date", "Time")

        Console.WriteLine("============================================================")

        'Ask them for the Booking they want
        For i = 0 To Bookings.Count - 1

            If Bookings(i).BComplete = False Then
                Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", i, Bookings(i).BName, Bookings(i).BDate.ToShortDateString, Bookings(i).BTime.ToShortTimeString)
            End If

        Next

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")

        Console.ReadKey(True)

    End Sub

    'Finished
    Sub AllComplete()

        Console.Clear()
        Console.WriteLine("Here's the Bookings currently in the program")
        Console.WriteLine()
        'Format a writeline into columns
        ' {0,-5} = The First column, is the ID, has 5 spaces
        ' {1,-20} = The Second column, is the Client's Name, has 20 spaces
        ' {2,-20} = The Third column, is the Booking Date, has 25 spaces
        ' {3,-20} = The Fourth column, is the Booking time, has 20 spaces
        Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", "ID", "Client's Name", "Date", "Time")

        Console.WriteLine("============================================================")

        'Ask them for the Booking they want
        For i = 0 To Bookings.Count - 1

            If Bookings(i).BComplete = True Then
                Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", i, Bookings(i).BName, Bookings(i).BDate.ToShortDateString, Bookings(i).BTime.ToShortTimeString)
            End If

        Next

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")

        Console.ReadKey(True)


    End Sub

    'Finished
    Sub SevenDaysIncomplete()


        Console.Clear()
        Console.WriteLine("Here's the Bookings currently in the program")
        Console.WriteLine()
        'Format a writeline into columns
        ' {0,-5} = The First column, is the ID, has 5 spaces
        ' {1,-20} = The Second column, is the Client's Name, has 20 spaces
        ' {2,-20} = The Third column, is the Booking Date, has 25 spaces
        ' {3,-20} = The Fourth column, is the Booking time, has 20 spaces
        Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", "ID", "Client's Name", "Date", "Time")

        Console.WriteLine("============================================================")

        'Ask them for the Booking they want
        For i = 0 To Bookings.Count - 1

            If Bookings(i).BComplete = False Then

                If Bookings(i).BDate <= Now.AddDays(7) Then
                    Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", i, Bookings(i).BName, Bookings(i).BDate.ToShortDateString, Bookings(i).BTime.ToShortTimeString)
                End If

            End If

        Next

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")

        Console.ReadKey(True)

    End Sub

    'Finished
    Sub ViewIncomplete()

        Console.Clear()

        For i = 0 To Bookings.Count - 1

            If Bookings(i).BComplete = False Then

                Console.Clear()
                Dim index As Integer = GetBookings(False)

                Console.WriteLine()
                Console.WriteLine("Here's the Booking!")

                Console.WriteLine()
                Console.WriteLine("Client's Name: " & Bookings(index).BName)
                Console.WriteLine("Address: " & Bookings(index).BAddress)
                Console.WriteLine("Phone Number: " & Bookings(index).BNumber)
                Console.WriteLine("Booking Date: " & Bookings(index).BDate)
                Console.WriteLine("Booking Time: " & Bookings(index).BTime)
                Console.WriteLine()
                Console.WriteLine("Press any key to continue...")
                Console.ReadKey(True)

                Console.Clear()
            End If
        Next

    End Sub

    'Finished
    Sub EditIncomplete()

        Console.Clear()
        Dim index As Integer = GetBookings(False)

        Console.WriteLine()
        Console.WriteLine("Here's the Booking!")

        Console.WriteLine()
        Console.WriteLine("Client's Name: " & Bookings(index).BName)
        Console.WriteLine("Address: " & Bookings(index).BAddress)
        Console.WriteLine("Phone Number: " & Bookings(index).BNumber)
        Console.WriteLine("Booking Date: " & Bookings(index).BDate)
        Console.WriteLine("Booking Time: " & Bookings(index).BTime)
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)


        Console.WriteLine("To edit a booking, enter the details below, leave blank if unchanged.")
        Console.WriteLine()
        Console.Write("Client's Name: ")
        Dim Name As String = Console.ReadLine
        If Name <> "" Then
            Bookings(index).BName = Name
        End If

        Console.Write("Client's Address: ")
        Dim Address As String = Console.ReadLine
        If Address <> "" Then
            Bookings(index).BAddress = Address
        End If

        Console.Write("Client's Phone Number: ")
        Dim Number As String = Console.ReadLine
        If Number <> "" Then
            Bookings(index).BNumber = Number
        End If

        Console.Write("Date of the booking (dd/mm/yy): ")
        Dim DateB As String = Console.ReadLine
        If DateB <> "" Then
            Bookings(index).BDate = DateB
        End If

        Console.Write("Time of the booking (hh:mm am/pm): ")
        Dim Time As String = Console.ReadLine
        If Time <> "" Then
            Bookings(index).BTime = Time
        End If



        Console.Clear()


    End Sub

    'Finished
    Sub RemoveBooking()

        Console.Clear()

        Console.WriteLine("Removing a Booking")
        Dim index As Integer = GetBookings(False)

        'Check the index is good
        If index >= 0 And index < Bookings.Count Then
            'Remove the booking they chose
            Bookings.RemoveAt(index)

        End If

        Console.WriteLine("Booking removed!")
        Console.ReadLine()


    End Sub

    'Finished
    Sub CompleteBooking()

        Dim x As String

        Console.Clear()
        Dim index As Integer = GetBookings(False)

        Console.WriteLine()
        Console.WriteLine("Here's the Booking!")

        Console.WriteLine()
        Console.WriteLine("Client's Name: " & Bookings(index).BName)
        Console.WriteLine("Address: " & Bookings(index).BAddress)
        Console.WriteLine("Phone Number: " & Bookings(index).BNumber)
        Console.WriteLine("Booking Date: " & Bookings(index).BDate)
        Console.WriteLine("Booking Time: " & Bookings(index).BTime)
        Console.WriteLine()
        Console.WriteLine("Are you sure you want to complete this booking (y/n)?")
        x = Console.ReadKey(True).KeyChar

        If x = "y" Then

            Bookings(index).BComplete = True

            Console.WriteLine("How many hours did it take to complete?")
            Pro1.CompleteHours += Console.ReadLine

        Else
            Console.WriteLine("Cancelled.")
            Console.WriteLine()
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey(True)
        End If

        Console.Clear()




    End Sub

    'Finished
    Sub CompanyDetails()

        Console.Clear()

        Console.WriteLine()
        Console.WriteLine("Here's your Details")

        Console.WriteLine()
        Console.WriteLine("Company Name: " & Pro1.CName)
        Console.WriteLine("Owner: " & Pro1.COwner)
        Console.WriteLine("Phone Number: " & Pro1.CNumber)
        Console.WriteLine("Company Address: " & Pro1.CAddress)
        Console.WriteLine("Pay Rate: " & Pro1.Rate)
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)


        Console.WriteLine("To edit, enter the details below, leave blank if unchanged.")
        Console.WriteLine()
        Console.Write("Company's Name: ")
        Dim Name As String = Console.ReadLine
        If Name <> "" Then
            Pro1.CName = Name
        End If

        Console.Write("Company Owner: ")
        Dim Owner As String = Console.ReadLine
        If Owner <> "" Then
            Pro1.COwner = Owner
        End If

        Console.Write("Company's Phone Number: ")
        Dim Number As String = Console.ReadLine
        If Number <> "" Then
            Pro1.CNumber = Number
        End If

        Console.Write("Company's Address: ")
        Dim Address As String = Console.ReadLine
        If Address <> "" Then
            Pro1.CAddress = Address
        End If

        Console.Write("Pay Rate: ")
        Dim Rate As String = Console.ReadLine
        If Rate <> "" Then
            Pro1.Rate = Rate
        End If

        Console.Clear()

    End Sub

    'Finished
    Sub BusinessCard()

        Console.Clear()

        Console.SetCursorPosition(13, 4)
        Console.WriteLine("/============================================\")
        Console.SetCursorPosition(13, 5)
        Console.WriteLine("|  " & Pro1.CName)
        Console.SetCursorPosition(13, 6)
        Console.WriteLine("|                                            |")
        Console.SetCursorPosition(13, 7)
        Console.WriteLine("|  Owner: " & Pro1.COwner)
        Console.SetCursorPosition(13, 8)
        Console.WriteLine("|                                            |")
        Console.SetCursorPosition(13, 9)
        Console.WriteLine("|                                            |")
        Console.SetCursorPosition(13, 10)
        Console.WriteLine("|  Phone Number: " & Pro1.CNumber)
        Console.SetCursorPosition(13, 11)
        Console.WriteLine("|  Address: " & Pro1.CAddress)
        Console.SetCursorPosition(13, 12)
        Console.WriteLine("|                                            |")
        Console.SetCursorPosition(13, 13)
        Console.WriteLine("\============================================/")
        Console.SetCursorPosition(58, 5)
        Console.WriteLine("|")
        Console.SetCursorPosition(58, 7)
        Console.WriteLine("|")
        Console.SetCursorPosition(58, 10)
        Console.WriteLine("|")
        Console.SetCursorPosition(58, 11)
        Console.WriteLine("|")

        Console.ReadLine()

    End Sub

    'Finished
    Sub Options()

        Dim selection As Char

        Do


            'Draw up the menu
            Console.Clear()
            Console.WriteLine("======================================================")
            Console.WriteLine("|                                                    |")
            Console.WriteLine("| Options:                                           |")
            Console.WriteLine("|                                                    |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (A) Edit Company Details                           |")
            Console.WriteLine("| (B) BackGround Colour                              |")
            Console.WriteLine("| (C) ForeGround Colour                              |")
            Console.WriteLine("| (D) Reboot                                         |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (X) Back                                           |")
            Console.WriteLine("======================================================")

            'Get the selected letter from the user
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper

            Select Case selection
                Case "A"
                    CompanyDetails()
                Case "B"
                    ProgramBackGroundColour()
                Case "C"
                    ProgramForeGroundColour()
                Case "D"
                    Reboot()
            End Select

        Loop Until selection = "X"


        Menu()

    End Sub

    Sub ProgramForeGroundColour()

        Dim selection As Char

        Do


            'Draw up the menu
            Console.Clear()
            Console.WriteLine("======================================================")
            Console.WriteLine("|                                                    |")
            Console.WriteLine("| ForeGround Colour                                  |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| Current Colour: " & Op1.colorselect)
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (A) Black                                          |")
            Console.WriteLine("| (B) Dark Blue                                      |")
            Console.WriteLine("| (C) Dark Green                                     |")
            Console.WriteLine("| (D) Dark Cyan                                      |")
            Console.WriteLine("| (E) Dark Red                                       |")
            Console.WriteLine("| (F) Dark Magenta                                   |")
            Console.WriteLine("| (G) Dark Yellow                                    |")
            Console.WriteLine("| (H) Grey                                           |")
            Console.WriteLine("| (I) Dark Grey                                      |")
            Console.WriteLine("| (J) Blue                                           |")
            Console.WriteLine("| (K) Green                                          |")
            Console.WriteLine("| (L) Cyan                                           |")
            Console.WriteLine("| (M) Red                                            |")
            Console.WriteLine("| (N) Magenta                                        |")
            Console.WriteLine("| (O) Yellow                                         |")
            Console.WriteLine("| (P) White                                          |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (X) Back                                           |")
            Console.WriteLine("======================================================")

            'Get the selected letter from the user
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper

            Select Case selection
                Case "A"
                    Op1.foreGroundColor = ConsoleColor.Black
                    Op1.colorselect = "Black"
                Case "B"
                    Op1.foreGroundColor = ConsoleColor.DarkBlue
                    Op1.colorselect = "Dark Blue"
                Case "C"
                    Op1.foreGroundColor = ConsoleColor.DarkGreen
                    Op1.colorselect = "Dark Green"
                Case "D"
                    Op1.foreGroundColor = ConsoleColor.DarkCyan
                    Op1.colorselect = "Dark Cyan"
                Case "E"
                    Op1.foreGroundColor = ConsoleColor.DarkRed
                    Op1.colorselect = "Dark Red"
                Case "F"
                    Op1.foreGroundColor = ConsoleColor.DarkMagenta
                    Op1.colorselect = "Dark Magenta"
                Case "G"
                    Op1.foreGroundColor = ConsoleColor.DarkYellow
                    Op1.colorselect = "Dark Yellow"
                Case "H"
                    Op1.foreGroundColor = ConsoleColor.Gray
                    Op1.colorselect = "Grey"
                Case "I"
                    Op1.foreGroundColor = ConsoleColor.DarkGray
                    Op1.colorselect = "Dark Grey"
                Case "J"
                    Op1.foreGroundColor = ConsoleColor.Blue
                    Op1.colorselect = "Blue"
                Case "K"
                    Op1.foreGroundColor = ConsoleColor.Green
                    Op1.colorselect = "Green"
                Case "L"
                    Op1.foreGroundColor = ConsoleColor.Cyan
                    Op1.colorselect = "Cyan"
                Case "M"
                    Op1.foreGroundColor = ConsoleColor.Red
                    Op1.colorselect = "Red"
                Case "N"
                    Op1.foreGroundColor = ConsoleColor.Magenta
                    Op1.colorselect = "Magenta"
                Case "O"
                    Op1.foreGroundColor = ConsoleColor.Yellow
                    Op1.colorselect = "Yellow"
                Case "P"
                    Op1.foreGroundColor = ConsoleColor.White
                    Op1.colorselect = "White"
            End Select

            Console.ForegroundColor = Op1.foreGroundColor
        Loop Until selection = "X"
        Options()

    End Sub

    'Finished
    Sub ProgramBackGroundColour()

        Dim selection As Char

        Do


            'Draw up the menu
            Console.Clear()
            Console.WriteLine("======================================================")
            Console.WriteLine("|                                                    |")
            Console.WriteLine("| Program Colour                                     |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| Current Colour: " & Op1.colorselect)
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (A) Black                                          |")
            Console.WriteLine("| (B) Dark Blue                                      |")
            Console.WriteLine("| (C) Dark Green                                     |")
            Console.WriteLine("| (D) Dark Cyan                                      |")
            Console.WriteLine("| (E) Dark Red                                       |")
            Console.WriteLine("| (F) Dark Magenta                                   |")
            Console.WriteLine("| (G) Dark Yellow                                    |")
            Console.WriteLine("| (H) Grey                                           |")
            Console.WriteLine("| (I) Dark Grey                                      |")
            Console.WriteLine("| (J) Blue                                           |")
            Console.WriteLine("| (K) Green                                          |")
            Console.WriteLine("| (L) Cyan                                           |")
            Console.WriteLine("| (M) Red                                            |")
            Console.WriteLine("| (N) Magenta                                        |")
            Console.WriteLine("| (O) Yellow                                         |")
            Console.WriteLine("| (P) White                                          |")
            Console.WriteLine("|----------------------------------------------------|")
            Console.WriteLine("| (X) Back                                           |")
            Console.WriteLine("======================================================")

            'Get the selected letter from the user
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper

            Select Case selection
                Case "A"
                    Op1.backGroundColor = ConsoleColor.Black
                    Op1.colorselect = "Black"
                Case "B"
                    Op1.backGroundColor = ConsoleColor.DarkBlue
                    Op1.colorselect = "Dark Blue"
                Case "C"
                    Op1.backGroundColor = ConsoleColor.DarkGreen
                    Op1.colorselect = "Dark Green"
                Case "D"
                    Op1.backGroundColor = ConsoleColor.DarkCyan
                    Op1.colorselect = "Dark Cyan"
                Case "E"
                    Op1.backGroundColor = ConsoleColor.DarkRed
                    Op1.colorselect = "Dark Red"
                Case "F"
                    Op1.backGroundColor = ConsoleColor.DarkMagenta
                    Op1.colorselect = "Dark Magenta"
                Case "G"
                    Op1.backGroundColor = ConsoleColor.DarkYellow
                    Op1.colorselect = "Dark Yellow"
                Case "H"
                    Op1.backGroundColor = ConsoleColor.Gray
                    Op1.colorselect = "Grey"
                Case "I"
                    Op1.backGroundColor = ConsoleColor.DarkGray
                    Op1.colorselect = "Dark Grey"
                Case "J"
                    Op1.backGroundColor = ConsoleColor.Blue
                    Op1.colorselect = "Blue"
                Case "K"
                    Op1.backGroundColor = ConsoleColor.Green
                    Op1.colorselect = "Green"
                Case "L"
                    Op1.backGroundColor = ConsoleColor.Cyan
                    Op1.colorselect = "Cyan"
                Case "M"
                    Op1.backGroundColor = ConsoleColor.Red
                    Op1.colorselect = "Red"
                Case "N"
                    Op1.backGroundColor = ConsoleColor.Magenta
                    Op1.colorselect = "Magenta"
                Case "O"
                    Op1.backGroundColor = ConsoleColor.Yellow
                    Op1.colorselect = "Yellow"
                Case "P"
                    Op1.backGroundColor = ConsoleColor.White
                    Op1.colorselect = "White"
            End Select

            Console.BackgroundColor = Op1.backGroundColor
        Loop Until selection = "X"
        Options()

    End Sub

    'Finished
    Sub Main()

        Loading()
        Startup()

        If IO.File.Exists("CompanyData.txt") = False Then
            ProfileSetup()
        Else
            LoadCompany()
        End If
        LoadBookings()

        Menu()
    End Sub

    Sub Reboot()

        Dim i As String

        Console.Clear()

        Console.SetCursorPosition(20, 5)
        Console.WriteLine("Warning! Reboot will delete all saved data!")
        Console.SetCursorPosition(25, 6)
        Console.Write("Do you wish to continue (y/n)")

        i = Console.ReadKey(True).KeyChar.ToString.ToUpper

        If i = "Y" Then

            Console.Clear()

            Console.WriteLine("Rebooting")
            Threading.Thread.Sleep(500)
            Console.Write(".")
            Threading.Thread.Sleep(500)
            Console.Write(".")
            Threading.Thread.Sleep(500)
            Console.WriteLine(".")
            Threading.Thread.Sleep(1000)

            Console.WriteLine("Deleting Company Data")
            IO.File.Delete("CompanyData.txt")
            Threading.Thread.Sleep(100)
            Console.WriteLine("_")
            Threading.Thread.Sleep(100)
            Console.WriteLine("_")
            Console.WriteLine("Deleting Booking Data")
            IO.File.Delete("BookingData.txt")
            Threading.Thread.Sleep(100)
            Console.WriteLine("_")
            Threading.Thread.Sleep(100)
            Console.WriteLine("_")
            Console.WriteLine("Options Booking Data")
            IO.File.Delete("Options.txt")
            Threading.Thread.Sleep(100)
            Console.WriteLine("_")
            Threading.Thread.Sleep(100)
            Console.WriteLine("_")
            Console.WriteLine("Reboot Finished")
            Threading.Thread.Sleep(100)
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey(True)
            Console.BackgroundColor = ConsoleColor.Black
            Console.ForegroundColor = ConsoleColor.Gray


            End

        Else

            Console.Clear()

            Console.WriteLine("Exiting")
            Threading.Thread.Sleep(500)
            Menu()
        End If

        

      

    End Sub

    'Finished
    Sub SaveCompany()

        'Save the students to a text file
        FileOpen(1, "CompanyData.txt", OpenMode.Output)

        'Fill the file
        PrintLine(1, Pro1.CName)
        PrintLine(1, Pro1.COwner)
        PrintLine(1, Pro1.CNumber)
        PrintLine(1, Pro1.CAddress)
        PrintLine(1, Pro1.Rate)


        FileClose(1)

    End Sub

    'Finished
    Sub SaveOptions()

        'Save the students to a text file
        FileOpen(3, "Options.txt", OpenMode.Output)

        'Fill the file
        PrintLine(3, Op1.backGroundColor)
        PrintLine(3, Op1.foreGroundColor)
        PrintLine(3, Op1.colorselect)
        PrintLine(3, Op1.forecolorselect)



        FileClose(3)

    End Sub

    'Finished
    Sub LoadOptions()

        'Check if the file exists
        If IO.File.Exists("Options.txt") Then

            'Open the file for reading
            FileOpen(3, "Options.txt", OpenMode.Input)





            Op1.backGroundColor = LineInput(3)
            Op1.foreGroundColor = LineInput(3)
            Op1.colorselect = LineInput(3)
            Op1.forecolorselect = LineInput(3)

            'Close our file
            FileClose(3)

        End If

    End Sub

    'Finished
    Sub SaveBookings()

        'Save the Booking to a text file
        FileOpen(2, "BookingData.txt", OpenMode.Output)

        For Each Client In Bookings

            'Fill the file
            PrintLine(2, Client.BName)
            PrintLine(2, Client.BAddress)
            PrintLine(2, Client.BNumber)
            PrintLine(2, Client.BDate)
            PrintLine(2, Client.BTime)

        Next

        FileClose(2)

    End Sub

    'Finished
    Sub LoadCompany()

        'Check if the file exists
        If IO.File.Exists("CompanyData.txt") Then

            'Open the file for reading
            FileOpen(1, "CompanyData.txt", OpenMode.Input)





            Pro1.CName = LineInput(1)
            Pro1.COwner = LineInput(1)
            Pro1.CNumber = LineInput(1)
            Pro1.CAddress = LineInput(1)
            Pro1.Rate = LineInput(1)



            'Close our file
            FileClose(1)

        End If

    End Sub

    'Finished
    Sub LoadBookings()

        'Check if the file exists
        If IO.File.Exists("BookingData.txt") Then

            'Open the file for reading
            FileOpen(1, "BookingData.txt", OpenMode.Input)

            'While we are not at the end of file
            While Not EOF(1)

                Dim newBooking As New Booking

                newBooking.BName = LineInput(1)
                newBooking.BAddress = LineInput(1)
                newBooking.BNumber = LineInput(1)
                newBooking.BDate = LineInput(1)
                newBooking.BTime = LineInput(1)

                Bookings.Add(newBooking)

            End While

            'Close our file
            FileClose(1)

        End If

    End Sub

End Module
