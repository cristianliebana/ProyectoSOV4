#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

typedef struct {
	char nombre[20];
	int socket;
}Conectado;

typedef struct {
	Conectado conectados [100];
	int num;
}ListaConectados;

typedef struct {
	int ID;
	int numParticipantes;
	Conectado conectados [8];
}Partida;

typedef struct {
	Partida partidas [100];
	int num;
}ListaPartidas;

int i;
int sockets[100];
char notificacion[500];
ListaConectados lista;
ListaPartidas listap;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int Conectarse (ListaConectados *lista, char nombre[20], int socket){
	if (lista->num == 100)
		return -1;
	else {
		strcpy (lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		return 0;
	}
}

int DevuelveSocket (ListaConectados *lista, char nombre[20]){

	int i=0;
	int encontrado = 0;
	while ((i< lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return lista->conectados[i].socket;
	else
		return -1;
}


int DevuelvePosicion (ListaConectados *lista, char nombre[20]){

	int i=0;
	int encontrado = 0;
	while ((i< lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}


int Eliminar (ListaConectados *lista, char nombre[20]){

	int pos = DevuelvePosicion (lista, nombre);
	if (pos == -1)
		return -1;
	else
	{
		int i;
		for (i=pos; i< lista->num-1; i++)
		{
			strcpy (lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			lista->conectados[i].socket = lista->conectados[i+1].socket;          
		}
		lista->num--;
		return 0;
	}
}


void DevuelveConectados (ListaConectados *lista, char conectados[500]){

	
	sprintf (conectados, "6/%d", lista->num);
	int i;
	for (i=0; i< lista->num; i++)
	{
		sprintf (conectados,"%s/%s", conectados, lista->conectados[i].nombre);
	}
}

int GetID (ListaPartidas *listap)
{
	int max = 0;
	for(int k = 0; k<listap->num; k++)
	{
		if (listap->partidas[k].ID > max)
			max = listap->partidas[k].ID;
	}
	return max+1;
}

int AnadirPartida (ListaPartidas *listap, int ID)
{
	if (listap->num == 100)
		return -1;
	else {
		listap->partidas[listap->num].ID = ID;
		listap->num++;
		return 0;
	}
}

int AnadirParticipante(ListaPartidas *listap, int ID, char nombre[20], int sock_conn)
{
	int encontrado = 0;
	int i = 0;
	while (i < listap->num && encontrado == 0)
	{
		if (listap->partidas[i].ID == ID)
			encontrado = 1;
		else
			i++;
	}
	strcpy(listap->partidas[i].conectados[listap->partidas[i].numParticipantes].nombre, nombre);
	listap->partidas[i].conectados[listap->partidas[i].numParticipantes].socket = sock_conn;
	listap->partidas[i].numParticipantes++;
}


int GanadorAbsoluto (char nombre[20], char resultado[150])
{
	MYSQL *conn;
	int err;

	MYSQL_RES *resultado_c;
	MYSQL_ROW row;
	char consulta [150];
	
 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "M1Juego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta, "SELECT ganador, COUNT( ganador ) AS total FROM  Partidas GROUP BY ganador ORDER BY total DESC;",nombre);
	
	err=mysql_query (conn, consulta); 
	if (err!=0) {
		sprintf (resultado,"3/Error al consultar datos de la base %u %s",
				 mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
 
	resultado_c = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado_c);
	
	if (row == NULL) {
		sprintf (resultado,"3/No se han obtenido datos en la consulta\n");
	
	}
	else
		sprintf(resultado,"3/%s",row[0]);
	
	return 0;
}

int PartidasFebrero(char nombre[20], char resultado[150])
{
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado_c;
	MYSQL_ROW row;
	char consulta [150];
	

	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexi\uffc3\uffb3n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "M1Juego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexi\uffc3\uffb3n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	
	sprintf (consulta, "SELECT COUNT(*) FROM Partidas WHERE fecha = 02;",nombre);	 
	err=mysql_query (conn, consulta); 
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado_c = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado_c);
	if (row == NULL){
		sprintf (resultado,"4/No se han obtenido datos en la consulta\n");
	}
	else
		sprintf(resultado,"4/%s",row[0]); 
	return 0;
}

int JuanTrentaPuntos (char nombre[20], char resultado[150])
{
	MYSQL *conn;
	int err;
	
	MYSQL_RES *resultado_c;
	MYSQL_ROW row;
	char consulta [150];
	

	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "M1Juego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta, "SELECT COUNT(*) FROM Partidas WHERE ganador ='Juan' AND puntosganador >30;",nombre);
	
	err=mysql_query (conn, consulta); 
	if (err!=0) {
		sprintf (resultado,"5/Error al consultar datos de la base %u %s",
				 mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado_c = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado_c);
	
	if (row == NULL){
		sprintf (resultado,"5/No se han obtenido datos en la consulta\n");
	}
	else
		sprintf(resultado,"5/%s",row[0]); 
	return 0;
	
}

int Registrarse (char usuario[20], char contrasena[20]) {	
	MYSQL *conn;
	MYSQL_RES *resultado_c;
	MYSQL_ROW row;
	int err;
	char consulta [80];
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "M1Juego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	err=mysql_query (conn, "SELECT * FROM Jugador");	if (err!=0) {
		printf ("Error al consultar la base de datos %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado_c = mysql_store_result (conn);
	int i = 0;
	row = mysql_fetch_row (resultado_c);
	while(row != NULL) {
		i++;
		row = mysql_fetch_row (resultado_c);
	}
	strcpy(consulta, "SELECT * FROM Jugador WHERE Jugador.nombre ='");
	strcat(consulta, usuario);
	strcat(consulta, "'");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado_c = mysql_store_result (conn);
	row = mysql_fetch_row (resultado_c);
	if(row != NULL) {
		printf("Error. Ya hay alguien con ese nombre.");
		exit (1);
	}
	sprintf(consulta, "INSERT INTO Jugador (id,nombre,password) VALUES ('%d','%s','%s');", i + 1, usuario, contrasena);
	
	printf("consulta = %s\n", consulta);
	
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	return 0;	
}

int LogIn(char usuario[20], char contrasena[20]) {
	MYSQL *conn;
	MYSQL_RES *resultado_c;
	MYSQL_ROW row;
	int err;
	char consulta [80];
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
 
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "M1Juego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	strcpy(consulta, "SELECT * FROM Jugador WHERE Jugador.nombre='");
	strcat(consulta, usuario);
	strcat(consulta, "' AND Jugador.password='");
	strcat(consulta, contrasena);
	strcat(consulta, "'");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado_c = mysql_store_result (conn);
	row = mysql_fetch_row (resultado_c);
	if(row == NULL) {
		printf("Error. Los datos no coinciden.");
		exit (1);
	}
	
	return 0;
}

void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	int error;
	
	
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
	int terminar =0;

	while (terminar ==0)
	{
		
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		

		peticion[ret]='\0';
		
	
		printf ("Se ha conectado: %s\n",peticion);
		
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		char nombre[20];
		p = strtok( NULL, "/");
		
		strcpy (nombre, p);
		printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
		int ID = 0;
		
		switch (codigo)
		{
		case 0:
			terminar = 1;
			pthread_mutex_lock(&mutex);
			Eliminar(&lista,nombre);
			pthread_mutex_unlock(&mutex);
			DevuelveConectados(&lista,notificacion);
			int j;
			for (j=0; j<i; j++)
			{
				write (sockets[j],notificacion, strlen(notificacion));
			}
			char respuesta0[50];
			strcpy(respuesta0,"0/Te has desconectado");
			write (sock_conn,respuesta0,strlen(respuesta0));
			break;
		case 1:
			
			p = strtok( NULL, "/");
			char respuesta1[50];
			char contrasena[20];
			strcpy (contrasena, p);
			error = Registrarse(nombre,contrasena);
			sprintf(respuesta1,"1/%s",nombre);
			write (sock_conn,respuesta1,strlen(respuesta1));
			
			if (error != 0)
				printf ("Ha ocurrido un error en el caso 1");
			
			break;
			
		case 2:
	
			p = strtok( NULL, "/");
			char respuesta2[50];
			strcpy (contrasena, p);
			error = LogIn(nombre,contrasena);
			sprintf(respuesta2,"2/%s",nombre);
			write (sock_conn,respuesta2,strlen(respuesta2));
			int numsocket = DevuelveSocket(&lista,nombre);
			
			if (error != 0)
				printf ("Ha ocurrido un error en el caso 2");
			
			pthread_mutex_lock(&mutex);
			int errorCON = Conectarse (&lista,nombre,numsocket);
			pthread_mutex_unlock(&mutex);
			
			if (errorCON != 0)
				printf ("Ha ocurrido un error en el caso 1, no se ha podido añadir a la lista de conectados");
			else		
				DevuelveConectados(&lista,notificacion);
			for (j=0; j<i; j++)
			{
				write (sockets[j],notificacion, strlen(notificacion));
			}
			
			break;
		case 3:
			error = GanadorAbsoluto(nombre,respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
			
			if (error != 0)
				printf ("Ha ocurrido un error en el caso 3");
			
			break;
			
		case 4:
			error = PartidasFebrero(nombre,respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
			
			if (error != 0)
				printf ("Ha ocurrido un error en el caso 4");
			
			break;
		case 5:
			error = JuanTrentaPuntos(nombre,respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
			
			if (error != 0)
				printf ("Ha ocurrido un error en el caso 5");
			break;
			
		case 6:
			ID = GetID(&listap);
			AnadirPartida(&listap,ID);
			AnadirParticipante(&listap,ID,nombre,sock_conn);
			strcpy(respuesta,"");
			sprintf(respuesta,"7/%d/%s",ID,nombre);
			p = strtok( NULL, "/");
			int numParticipantes =  atoi (p);
			int i=0;
			j=0;
			char invitado[20];
			
			while(i<numParticipantes-1)
			{
				p = strtok( NULL, "/");
				strcpy(invitado,p);
				j=0;
				while(j < lista.num)
				{
					if (strcmp(invitado, lista.conectados[j].nombre)==0)
						
						write (sockets[j],respuesta, strlen(respuesta));
					j++;
				}
				i++;
			}
			break;
			
		case 7:
		
			p = strtok( NULL, "/");
			int ID =  atoi (p);			
			
			p = strtok( NULL, "/");
			int SiNo =  atoi (p);	
			
			if( SiNo == 1)
			{
				int sock = DevuelveSocket(&lista,nombre);
				AnadirParticipante(&listap,ID,nombre,sock);
			}			
			
			if (error != 0)
				printf ("Ha ocurrido un error en el caso 7");
			
		default:
			
			// statements executed if expression does not equal
			// any case constant_expression
			break;
		}
		
	}
	
	close(sock_conn); 
}

int main(int argc, char *argv[])
{
	lista.num=0;
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	int puerto = 50001;
	char peticion[512];
	char respuesta[512];

	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	

	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	
	serv_adr.sin_port = htons(puerto);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
	
	
	pthread_t thread;
	i=0;
	printf ("Escuchando\n");
	
	for(;;){
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
	}
	
}
