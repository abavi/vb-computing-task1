Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'First we create variables that will store every textbox information
        Dim borrow As Integer ' Ammount of money to borrow
        Dim interestRate As Double ' The interest rate that will be applied
        Dim lifeLoan As Integer ' The life of the loan expressed in years

        'We also create two variables that will hold the monthly interest rate and the number of payments in months
        Dim monthlyRate As Double ' This variable will hold the monthly interest rate
        Dim numberOfPayments As Integer ' This variable will hold the total number of payments (in months)

        'Now we will create the variables that change based on the given information
        Dim monthlyPayments As Double ' Ammount of money you will pay monthly ( will use float values)
        Dim totalPayments As Double ' Ammount of money you will in total after the interest charges (will use float values)

        'Storing the information from the textboxes. The need to be parsed from string to the correct type
        borrow = CInt(TextBox1.Text) ' The value from the first box gets stored in variable borrow
        interestRate = CDbl(TextBox2.Text) ' The value from the second box gets stored in variable interestRate
        lifeLoan = CInt(TextBox3.Text) ' The value from the third box gets stored in variable lifeLoan


        ' Assigning the values needed for the monthly payment formula
        monthlyRate = interestRate / 12 ' To calculate the monthly payments we will need to divide the interestRate to 12 months
        numberOfPayments = lifeLoan * 12 ' We will also need to calculate the total number of payments in months by multiplying the loanLife to 12 months

        'The monthly payment formula will look like: (borrow * monthlyRate * ((1 + monthlyRate) ^ numberOfMonths)) / ((1 + monthlyRate) ^ numberOfPayments) - 1 




    End Sub

End Class
