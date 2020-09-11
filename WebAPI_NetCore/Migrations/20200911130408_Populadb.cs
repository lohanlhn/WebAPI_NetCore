using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_NetCore.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Categorias(Nome,ImageUrl) values('Bebidas', 'https://saofranciscodoconde.ba.gov.br/wp-content/uploads/2017/04/agua11.jpg')");
            mb.Sql("insert into Categorias(Nome,ImageUrl) values('Lanches', 'https://nerilanches.com.br/dominios/nerilanches.com.br/img/slider/slide1.png')");
            mb.Sql("insert into Categorias(Nome,ImageUrl) values('Sobremesas', 'https://www.sabornamesa.com.br/media/k2/items/cache/dd45d054dfce696b68bc0b43a11d1bfe_L.jpg')");

            mb.Sql("insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId)" +
                    "values('Lanche de Atum', 'Lanche de Atum com maionese', 8.50, " +
                    "'https://img.itdg.com.br/tdg/images/recipes/000/003/165/38827/38827_original.jpg',10, GETDATE(), (select CategoriaId from Categorias where Nome= 'Lanches'))");

            mb.Sql("insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId)" +
                    "values('Pudim 100g', 'Pudim de leite condensado', 6.75, " +
                    "'https://img.itdg.com.br/tdg/images/recipes/000/031/593/318825/318825_original.jpg',20, GETDATE(), (select CategoriaId from Categorias where Nome= 'Sobremesas'))");

            mb.Sql("insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId)" +
                    "values('Coca-Cola Diet', 'Refrigerante de Cola 350ml', 5.45, " +
                    "'https://images-na.ssl-images-amazon.com/images/I/41NZjtqw9nL.jpg',50, GETDATE(), (select CategoriaId from Categorias where Nome= 'Bebidas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
