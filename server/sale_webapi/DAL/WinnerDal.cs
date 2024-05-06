using AutoMapper;
using sale_webapi.Models;
using server.Models;

namespace sale_webapi.DAL;

public class WinnerDal : IWinnerDal
{

    private readonly OrdersContext _orderContext;
    private readonly IMapper _mapper;

    public WinnerDal(OrdersContext orderContext, IMapper mapper)
    {
        this._orderContext = orderContext;
        this._mapper = mapper;

    }
    public async Task<ObjectToRaffle> RaffleAsync(string giftName)
    {
        var _giftName = await _orderContext.Gift.FirstOrDefaultAsync(g => g.Name == giftName);
        Random _random = new Random();
        List<int> names = new();
        List<OrderItem> _ordersitems = await _orderContext.OrderItem.Where(o => o.GiftId == _giftName.GiftId).ToListAsync();
        foreach (var item in _ordersitems)
        {
            for (int i = 0; i < item.Qty; i++)
            {
                names.Add(item.Id);
            }
        }

        int randomWin = _random.Next(0, names.Count);
        int winner = names[randomWin];
        //var userNameWinner = winner.Order.User.UserName;

        User user = await this._orderContext.User.FirstOrDefaultAsync(appuser => appuser.UserId == winner);
        Winner win = new Winner();
        win.UserId = user.UserId;

        //win.User.UserName = user.UserName;
        //win.User.FirstName = user.FirstName;
        //win.User.LastName = user.LastName;
        //win.User.PhonNumber = user.PhonNumber;
        //win.User.Email = user.Email;
        win.RaffleDate = DateTime.Now;
        win.GiftId = _giftName.GiftId;

       
        await _orderContext.Winner.AddAsync(win);
        await _orderContext.SaveChangesAsync();

        ObjectToRaffle objectToRaffle = new ObjectToRaffle();
            objectToRaffle.nameUser = win.User.UserName;
        return objectToRaffle;

    }
    public async Task<List<string>> Creating_a_report_winnersAsync()
    {
        List<Winner> winners = await _orderContext.Winner.ToListAsync();
        List<string> newList = new List<string>();
        foreach (var item in winners)
        {
            User user = await _orderContext.User.FirstOrDefaultAsync(w => w.UserId == item.UserId);
            string nameUser = user.UserFirstName + user.UserLastName;
            Gift gift = await _orderContext.Gift.FirstOrDefaultAsync(g => g.GiftId == item.GiftId);
            string nameGift = gift.Name;
            newList.Add($"{nameUser} win {nameGift} ");
       

        }
       
        return newList;
    }
   
}
