Module Module1
    Dim textColor As ConsoleColor
    Dim backGroundColor As ConsoleColor

    Class Booking
        Public BName As String
        Public BAddress As String
        Public BNumber As String
        Public BDate As Date
        Public BTime As Date
    End Class

    Dim Bookings As New List(Of Booking)
    Class Profiles
        Public CName As String
        Public COwner As String
        Public CNumber As Integer
        Public CAddress As String
        Public Rate As Single
    End Class

    Dim Pro1 As New Profiles

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
        Pro1.CNumber = Console.readline
        Console.Write("Company Address: ")
        Pro1.CAddress = Console.ReadLine
        Console.Write("Company Hourly Rate: ")
        Pro1.Rate = Console.ReadLine
        Console.WriteLine()
        Console.WriteLine("Setup is Complete!")

    End Sub

    Sub Menu()


        Dim selection As Char

        Do

            'Save company data
            SaveCompany()

            'Draw up the menu
            Console.Clear()
            Console.WriteLine("Welcome " & Pro1.COwner)
            Console.WriteLine("-------------------------------------------------------")
            Console.WriteLine("Total completed hours: (PLACEHOLDER)")
            Console.WriteLine("Total income:          (PlACEHOLDER)")
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

        If x = "y" Then

            Console.WriteLine("Booking added!")
            SaveBookings()

        ElseIf x = "n" Then

            Console.WriteLine("Booking cancelled.")

        End If

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)


    End Sub

    Sub AllIncomplete()

        Console.Clear()
        Console.WriteLine("View incomplete jobs")
        Console.WriteLine()
        Console.WriteLine("{0,-27} {1,-22} {2,-22}", "Client's Name", "Date", "Time")
        Console.WriteLine("-------------------------------------------------------")
        Console.ReadLine()

    End Sub

    Sub AllComplete()

        Console.Clear()

    End Sub

    Sub SevenDaysIncomplete()

        Console.Clear()

    End Sub

    Sub ViewIncomplete()

        Console.Clear()

    End Sub

    Sub EditIncomplete()

        Console.Clear()

    End Sub

    Sub RemoveBooking()

        Console.Clear()

    End Sub

    Sub CompleteBooking()

        Console.Clear()

    End Sub

    Sub BusinessCard()

        Console.Clear()

    End Sub

    Sub Main()


        Startup()

        If IO.File.Exists("CompanyData.txt") = False Then
            ProfileSetup()
        Else
            LoadCompany()
        End If

        Menu()
    End Sub

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

    Sub SaveBookings()

        'Save the Booking to a text file
        FileOpen(2, "BookingData.txt", OpenMode.Output)

        For Each Client In Bookings

            'Fill the file
            PrintLine(1, Client.BName)
            PrintLine(1, Client.BAddress)
            PrintLine(1, Client.BNumber)
            PrintLine(1, Client.BDate)
            PrintLine(1, Client.BTime)

        Next
      
        FileClose(2)

    End Sub

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
