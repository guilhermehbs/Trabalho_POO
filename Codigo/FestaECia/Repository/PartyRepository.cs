using System.Data.SqlClient;
using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Repository;

public class PartyRepository : IGet<Party>, ISet<Party>
{
	private readonly Database _database;

	public PartyRepository()
	{
		_database = new Database();
	}

	public List<Party> GetAll()
	{
		var parties = new List<Party>();

		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand("SELECT * FROM tb_party", connection);

			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					parties.Add(RenderParty(reader));
				}
			}
		}

		return parties;
	}

	public Party GetById(int id)
	{
		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand($"SELECT * FROM tb_space WHERE Id = {id}", connection);
			command.Parameters.AddWithValue("@Id", id);

			using (var reader = command.ExecuteReader())
			{
				if (reader.Read())
				{
					return RenderParty(reader);
				}
			}
		}

		return null;
	}

	public void Insert(Party party)
	{
		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand($"INSERT INTO tb_party (date, number_of_guests, space_id, type_party, price) VALUES" +
			                             $"('{party.Date}', {party.NumberOfGuests}, {party.Space.Id}, '{party.Type}', {party.Price})", connection);
			command.ExecuteNonQuery();
		}
	}

	public void Update(Party party)
	{
		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand($"UPDATE tb_party SET date = '{party.Date}', number_of_guests = {party.NumberOfGuests}, space_id = {party.Space.Id}, " +
			                             $"type_party = '{party.Type}', price = {party.Price} WHERE id = {party.Id}", connection);

			command.ExecuteNonQuery();
		}
	}

	public void Delete(int id)
	{
		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand($"DELETE FROM tb_party WHERE Id = {id}", connection);

			command.ExecuteNonQuery();
		}
	}

	private Party RenderParty(SqlDataReader reader)
	{
		var partyType = (PartyType)reader["type"];

		int id = (int)reader["id"];
		DateTime date = (DateTime)reader["date"];
		int numberOfGuests = (int)reader["number_of_people"];
		Space space = (Space)reader["space_name"];
		double price = (double)reader["Price"];
		
		Party party;

		switch (partyType)
		{
			case PartyType.Birthday:
				party = new BirthdayParty(id, date, numberOfGuests, space, partyType, price);
				break;
			case PartyType.Corporate:
				party = new CompanyParty(id, date, numberOfGuests, space, partyType, price);
				break;
			case PartyType.Free:
				party = new FreeParty(id, date, numberOfGuests, space, partyType, price);
				break;
			case PartyType.Graduation:
				party = new GraduationParty(id, date, numberOfGuests, space, partyType, price);
				break;
			case PartyType.Wedding:
				party = new WeddingParty(id, date, numberOfGuests, space, partyType, price);
				break;
			default:
				throw new InvalidOperationException("Unknown party type");
				break;
		}
		return party;
	}
}