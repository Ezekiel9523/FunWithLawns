Module Module1
    Dim textColor As ConsoleColor
    Dim backGroundColor As ConsoleColor

    Class Bookings
        Public BName As String
        Public BAddress As String
        Public BNumber As String
        Public BDate As Date
        Public BTime As Date
    End Class

    Dim Booking As New List(Of Bookings)
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

        'Change Later for Profiles
        Console.Clear()
        Console.WriteLine("No company information has been found, We'll set up a profile before we begin.")
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)


    End Sub

    Sub ProfileSetup()

        Console.Clear()

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

            'Draw up the menu
            Console.Clear()
            Console.WriteLine("Welcome " & Pro1.COwner)
            Console.WriteLine("-------------------------------------------------------")
            Console.WriteLine("Total completed hours: (PLACEHOLDER)")
            Console.WriteLine("Total income:          (PlACEHOLDER)")
            Console.WriteLine("-------------------------------------------------------")
            Console.WriteLine()
            Console.WriteLine("Select from one of the following menu options: ")
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

        Dim newBooking As New Bookings

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

        Console.WriteLine("Booking details are as follows:")
        Console.SetCursorPosition(9, 1)




    End Sub

    Sub AllIncomplete()

    End Sub

    Sub AllComplete()

    End Sub

    Sub SevenDaysIncomplete()

    End Sub

    Sub ViewIncomplete()

    End Sub

    Sub EditIncomplete()

    End Sub

    Sub RemoveBooking()

    End Sub

    Sub CompleteBooking()

    End Sub

    Sub BusinessCard()

    End Sub

    Sub Main()

        Startup()
        ProfileSetup()
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

        For Each Client In Booking

            'Fill the file
            PrintLine(1, Client.BName)
            PrintLine(1, Client.BAddress)
            PrintLine(1, Client.BNumber)
            PrintLine(1, Client.BDate)
            PrintLine(1, Client.BTime)

        Next
      
        FileClose(2)

    End Sub

End Module
