using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    public class BranchesLogic : BaseLogic
    {
        public BranchesLogic(CarRentalContext db) : base(db) { }
        public List<BranchModel> GetAllBranches()
        {
            return DB.Branches.Select(b => new BranchModel(b)).ToList();
        }
        public BranchModel GetOneBranch(int id)
        {
            return DB.Branches.Where(b => b.BranchId == id).Select(b => new BranchModel(b))
                .SingleOrDefault();
        }
        public BranchModel AddBranch(BranchModel branchModel)
        {
            Branch branchToAdd = branchModel.ConvertToBranch();
            DB.Branches.Add(branchToAdd);
            DB.SaveChanges();
            branchModel.ID = branchToAdd.BranchId;
            return branchModel;
        }
        public BranchModel UpdateFullBranch(BranchModel branchModel)
        {
            Branch branch = DB.Branches.SingleOrDefault(b => b.BranchId == branchModel.ID);
            if (branch == null)
                return null;

            branch.BranchId = branchModel.ID;
            branch.BranchName = branchModel.Name;
            branch.City = branchModel.City;
            branch.Country = branchModel.Country;
            branch.Email = branchModel.Email;
            branch.Latitude = branchModel.Latitude;
            branch.Longitude = branchModel.Longitude;
            branch.Phone = branchModel.Phone;
            DB.SaveChanges();
            return branchModel;
        }
        public BranchModel UpdatePartialBranch(BranchModel branchModel)
        {
            Branch branch = DB.Branches.SingleOrDefault(b => b.BranchId == branchModel.ID);
            if (branch == null)
                return null;

            if (branchModel.ID != null)
                branch.BranchId = branchModel.ID;
            if (branchModel.Name != null)
                branch.BranchName = branchModel.Name;
            if (branchModel.City != null)
                branch.City = branchModel.City;
            if (branchModel.Country != null)
                branch.Country = branchModel.Country;
            if (branchModel.Email != null)
                branch.Email = branchModel.Email;
            if (branchModel.Latitude != null)
                branch.Latitude = branchModel.Latitude;
            if (branchModel.Longitude != null)
                branch.Longitude = branchModel.Longitude;
            if (branchModel.Phone != null)
                branch.Phone = branchModel.Phone;

            DB.SaveChanges();
            return branchModel;
        }
        public void DeletBranch(int id)
        {
            Branch branchToDelete = DB.Branches.SingleOrDefault(b => b.BranchId == id);
            if (branchToDelete == null)
                return;
            DB.Branches.Remove(branchToDelete);
            DB.SaveChanges();
        }
    }
}
