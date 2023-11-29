using Sibi;

Tela tela = new Tela();
BancoDados bancoDados = new BancoDados();
HospedeCRUD hospede = new HospedeCRUD(bancoDados, tela);
HotelCRUD hotel = new HotelCRUD(bancoDados, tela);
PagamentoCRUD pagamento = new PagamentoCRUD(bancoDados, tela);
QuartoCRUD quarto = new QuartoCRUD(bancoDados, tela);
RedeHoteisCRUD redehoteis = new RedeHoteisCRUD(bancoDados, tela);
ReservaCRUD reserva = new ReservaCRUD(bancoDados, tela);
ServicoExtraCRUD servicoextra = new ServicoExtraCRUD(bancoDados, tela);


List<string> menu = new List<string>();
menu.Add("1 - Cadastro/Controle de Reservas ");
menu.Add("2 - Cadastro de Hospedes          ");
menu.Add("3 - Controle de Quartos           ");
menu.Add("4 - Controle de Pagamentos        ");
menu.Add("5 - Controle de Serviços Extras   ");
menu.Add("0 - Sair                          ");

string op;

while (true)
{
    tela.montarTelaSistema("Sistemas de Anotações");
    op = tela.mostrarMenu(menu, 3, 3);

    if (op == "0") break;
    if (op == "1") reserva.executarCRUD();
    if (op == "2") hospede.executarCRUD();
    if (op == "3") quarto.executarCRUD();
    if (op == "4") pagamento.executarCRUD();
    if (op == "5") servicoextra.executarCRUD();
}