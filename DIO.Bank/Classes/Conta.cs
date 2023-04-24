using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Bank.Enum;

namespace DIO.Bank.Conta
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
    {
        this.TipoConta = tipoConta;
        this.Nome = nome;
        this.Credito = credito;
        this.Saldo = saldo;
    }
    public bool Sacar(double valorSaque)
    {
        //Validação de saldo suficiente
        if(this.Saldo -valorSaque<(this.Credito*-1))
        {
            System.Console.WriteLine("Saldo insuficiente!");
            return false;
            }
            this.Saldo -= valorSaque;
            System.Console.WriteLine($"Saque efetuado com sucesso, seu novo saldo é de R${this.Saldo}");
            return true;

    }
    public void Depositar(double valorDeposito)
    {
        this.Saldo+=valorDeposito;
        System.Console.WriteLine($"Depósito efetuado com sucesso, seu novo saldo é de R${this.Saldo}");
    }
    public void Transferir(double valorTransferencia, Conta contaDestino)
    {
        if(this.Sacar(valorTransferencia))
        {
                contaDestino.Depositar(valorTransferencia);
            }
    }
    
    public override string ToString()
    {
        string retorno = "";
            retorno += "TipoConta " + this.TipoConta +" | ";
            retorno += "Nome " + this.Nome +" | ";
            retorno += "Saldo R$ " + this.Saldo +" | ";
            retorno += "Crédito R$ " + this.Credito;
            return retorno;
        }


    }
}