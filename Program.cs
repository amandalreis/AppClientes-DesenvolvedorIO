using System.Globalization;
using Entidades;
using Repositories;

//Isso aqui é para fazer com que as datas sejam reconhecidas como no padrão PT-BR quando forem fornecidas pelo usuário.
var cultura = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultura;
CultureInfo.DefaultThreadCurrentUICulture = cultura;

var clienteRepository = new ClienteRepository();
clienteRepository.LerClientes();
var menu = new Menu(clienteRepository);
menu.MostrarMenu();