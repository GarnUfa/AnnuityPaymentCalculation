let plholder = document.querySelector("input[name='PaymentStep']");
let loanTerm = document.querySelector("input[name='LoanTerm']");
loanTerm.oninput = function () {
    plholder.setAttribute("placeholder", "от 1 до " + loanTerm.value)
};