Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'First we create variables that will store every textbox information
        Dim borrow As Integer ' Ammount of money to borrow
        Dim interestRate As Double ' The interest rate that will be applied (this is a precentage)
        Dim lifeLoan As Integer ' The life of the loan expressed in years

        'We also create two variables that will hold the monthly interest rate and the number of payments in months
        Dim monthlyRate As Double ' This variable will hold the monthly interest rate
        Dim numberOfPayments As Integer ' This variable will hold the total number of payments (in months)

        'Now we will create the variables that change based on the given information
        Dim monthlyPayments As Double ' Ammount of money you will pay monthly ( will use float values)
        Dim totalPayments As Double ' Ammount of money you will in total after the interest charges (will use float values)

        'Storing the information from the textboxes. The need to be parsed from string to the correct type
        borrow = CInt(TextBox1.Text) ' The value from the first box gets stored in variable borrow
        interestRate = CDbl(TextBox2.Text) / 100 ' The value from the second box gets stored in variable interestRate
        '                                          (divided by 100 as it's a precentage)
        lifeLoan = CInt(TextBox3.Text) ' The value from the third box gets stored in variable lifeLoan


        ' Assigning the values needed for the monthly payment formula
        monthlyRate = interestRate / 12 ' To calculate the monthly payments we will need to divide the interestRate to 12 months
        numberOfPayments = lifeLoan * 12 ' We will also need to calculate the total number of payments in months
        '                                  by multiplying the loanLife with 12 months

        'The monthly payment formula will be a fraction multiplied with the ammount of borrowed money
        Dim topPart As Double ' This will be the nominator of the fraction
        Dim bottomPart As Double ' This will be the denominator of the fraction
        topPart = monthlyRate * ((1 + monthlyRate) ^ numberOfPayments)
        bottomPart = ((1 + monthlyRate) ^ numberOfPayments) - 1
        monthlyPayments = borrow * (topPart / bottomPart) ' The final part of the formula is to multiply it by the borrowed ammount
        TextBox4.Text = FormatCurrency(monthlyPayments) ' Now we display the monthly payments in the 4th text box with 2 decimal points

        'Now we need to calculate the total ammount of payments, after the interest is charged
        totalPayments = monthlyPayments * numberOfPayments ' Now we're multiplying the monthly payments with the total number of payments
        TextBox5.Text = FormatCurrency(totalPayments) ' Displaying the total payments with 2 decimal points
        ' This will show the user the total ammount that he is going to pay
        ' We will also show to user the ammount of interest he's going to pay in total, separate to the total payments
        Dim paidInterest As Double
        paidInterest = totalPayments - borrow ' This is done by calculating the difference between the borrowed ammount and actual paid ammount
        TextBox6.Text = FormatCurrency(paidInterest) ' Displaying the paid interest with 2 decimal points

    End Sub


End Class
