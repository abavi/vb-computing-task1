Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    'I need to make sure that the user can only input numbers in the first three text boxes
    'For every text box when the key is pressed it is then checked if it's a number or a comma or a dot
    'If it is not a number or a comma or a dot the text box won't get the input that it is given
    'The textbox will also accept the Back key to delete numbers
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        'The textbox checks if the key pressed is a number
        'The underscore operator tells VB that the statement continues on a new line
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") _
            AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "," Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        'The textbox checks if the key pressed is a number
        'The underscore operator tells VB that the statement continues on a new line
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") _
            AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "," Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        'The textbox checks if the key pressed is a number
        'The underscore operator tells VB that the statement continues on a new line
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") _
            AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "," Then
            e.Handled = True
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'First I create variables that will store every textbox information
        Dim borrow As Integer ' Ammount of money to borrow
        Dim interestRate As Double ' The interest rate that will be applied (this is a precentage)
        Dim lifeLoan As Integer ' The life of the loan expressed in years

        'I also create two variables that will hold the monthly interest rate and the number of payments in months
        Dim monthlyRate As Double ' This variable will hold the monthly interest rate
        Dim numberOfPayments As Integer ' This variable will hold the total number of payments (in months)

        'Now I will create the variables that change based on the given information
        Dim monthlyPayments As Double ' Ammount of money the user will pay monthly ( will use float values)
        Dim totalPayments As Double ' Ammount of money the user will pay in total after the interest charges (will use float values)

        'Storing the information from the textboxes. They need to be parsed from string to the correct type
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
        TextBox4.Text = FormatCurrency(monthlyPayments) ' Now I display the monthly payments in the 4th text box with 2 decimal points

        'Now I need to calculate the total ammount of payments, after the interest is charged
        totalPayments = monthlyPayments * numberOfPayments ' I am multiplying the monthly payments with the total number of payments
        TextBox5.Text = FormatCurrency(totalPayments) ' Displaying the total payments with 2 decimal points
        ' This will show the user the total ammount that he is going to pay
        ' I will also show to user the ammount of interest he's going to pay in total, separate to the total payments
        Dim paidInterest As Double
        paidInterest = totalPayments - borrow ' This is done by calculating the difference between the borrowed ammount and actual paid ammount
        TextBox6.Text = FormatCurrency(paidInterest) ' Displaying the paid interest with 2 decimal points

    End Sub


End Class
