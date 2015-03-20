Module Module1
    Dim textColor As ConsoleColor
    Dim backGroundColor As ConsoleColor

    Class Booking
        Public BName As String
        Public BAddress As String
        Public BNumber As String
        Public BDate As Date
        Public BTime As Date
        Public BComplete As Boolean
    End Class

    Public CompleteHours As Integer

    Dim Bookings As New List(Of Booking)
    Class Profiles
        Public CName As String
        Public COwner As String
        Public CNumber As Integer
        Public CAddress As String
        Public Rate As Single
    End Class

    Dim Pro1 As New Profiles

    'Finished
    Function GetBookings()




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

            Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", i, Bookings(i).BName, Bookings(i).BDate.ToShortDateString, Bookings(i).BTime.ToShortTimeString, Bookings(i).BTime)

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

        Dim Pay As Double = Pro1.Rate * CompleteHours

        Dim selection As Char

        Do

            'Save company data
            SaveCompany()

            'Draw up the menu
            Console.Clear()
            Console.WriteLine("Welcome " & Pro1.COwner)
            Console.WriteLine("-------------------------------------------------------")
            Console.WriteLine("Total completed hours: " & CompleteHours)
            Console.WriteLine("Total income:         $" & Pay)
            Console.WriteLine("-------------------------------------------------------")
            Console.WriteLine()
            Console.WriteLine("Select from one of the following menu options: ")
            Console.WriteLine()
            Console.WriteLine(" (A) Add a booking")
            Console.WriteLine(" (B) View all incomplete bookings")
            Console.WriteLine(" (C) View all complete booking")
            Console.WriteLine(" (D) Check incomplete bookings for next 7 days")
            Console.WriteLine()
            Console.WriteLine(" (E) View incomplete booking details")
            Console.WriteLine(" (F) Edit incomplete booking details")
            Console.WriteLine()
            Console.WriteLine(" (G) Remove a booking")
            Console.WriteLine(" (H) Complete a booking")
            Console.WriteLine()
            Console.WriteLine(" (I) View business card")
            Console.WriteLine()
            Console.WriteLine(" (X) Exit")
            SaveBookings()
            SaveCompany()

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

    Sub SevenDaysIncomplete()

        Console.Clear()

    End Sub

    'Finished
    Sub ViewIncomplete()

        For i = 0 To Bookings.Count - 1

            If Bookings(i).BComplete = False Then

                Console.Clear()
                Dim index As Integer = GetBookings()

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

    Sub EditIncomplete()

        Console.Clear()

    End Sub

    Sub RemoveBooking()

        Console.Clear()

        Console.WriteLine("Removing a Booking")
        Dim index As Integer = GetBookings()

        'Check the index is good
        If index >= 0 And index < Bookings.Count Then
            'Remove the booking they chose
            Bookings.RemoveAt(index)

        End If

        Console.WriteLine("Booking removed!")
        Console.ReadLine()


    End Sub

    Sub CompleteBooking()

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
    Sub Main()


        Startup()

        If IO.File.Exists("CompanyData.txt") = False Then
            ProfileSetup()
        Else
            LoadCompany()
        End If
        LoadBookings()

        Menu()
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
