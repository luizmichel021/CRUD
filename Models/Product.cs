
namespace CRUD_PRODUCTS.Models
{
     public class Product
     {
        private int id;
        private string nome;
        private double preco;
        private int quantidade;
        

        public int Id
        {
            get {return id;}
            set {id = value;}
        }

        public string Nome
        {
            get {return nome;}
            set {nome = value;}
        }

        public double Preco
        {
            get {return preco;}
            set {preco = value;}
        }

        public int Quantidade
        {
            get{return quantidade;}
            set{quantidade = value;}
        }

    

        public Product(){}
        public Product(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }
    
        public Product(int id,string nome, double preco, int quantidade)
        {   
            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            

        }
    
    }

}