using Microsoft.AspNetCore.Mvc;
using MyRshop.Data;
using MyRshop.Data.Repositories;
using MyRshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Component
{
    public class ProductGropsComponent:ViewComponent
    {
        private IGroupRepository _GroupRepository;
        public ProductGropsComponent(IGroupRepository GroupRepository)
        {
            _GroupRepository = GroupRepository; 
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("/Views/Components/ProductGropsComponent.cshtml", _GroupRepository.GetGroupForShow());
        }
    }
}
