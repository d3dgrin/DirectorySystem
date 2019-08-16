using AutoMapper;
using DirectorySystem.Business.DTO;
using DirectorySystem.Business.Interfaces;
using DirectorySystem.Helpers;
using DirectorySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectorySystem.Controllers
{
    public class DirectorySystemController : Controller
    {
        private readonly IHierarchyNodeService service;

        public DirectorySystemController(IHierarchyNodeService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            // prepare response
            var response = new DirectorySystemIndexViewModel() { Errors = new List<string>() };

            // get root node
            HierarchyNodeDTO rootNodeDTO = service.GetRootNode();

            // map root node
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HierarchyNodeDTO, HierarchyNodeViewModel>()).CreateMapper();
            var rootNode = mapper.Map<HierarchyNodeDTO, HierarchyNodeViewModel>(rootNodeDTO);

            // if no any root nodes in database, return error
            if (rootNode == null)
            {
                response.Errors = new List<string>() { "There are no directories on the selected path." };
                return View(response);
            }

            // get uri path
            var uriPath = Request.Url.AbsolutePath;

            // if root path, return root node
            if (uriPath.Equals("/"))
            {
                response.Node = rootNode;
                response.Url = $"{uriPath}{rootNode.Name}/";
                return View(response);
            }

            // get parts of uri path
            var parts = UriHelper.GetPartsOfUri(uriPath);

            // get node by parts. this is necessary because there can be nodes with the same name at different levels
            var currentNodeDTO = service.GetNode(parts, new List<HierarchyNodeDTO> { rootNodeDTO });

            // map node
            var currentNode = mapper.Map<HierarchyNodeDTO, HierarchyNodeViewModel>(currentNodeDTO);

            // if node not found, return error
            if (currentNode == null)
            {
                response.Errors = new List<string>() { "There are no directories on the selected path." };
                return View(response);
            }

            // return response
            response.Url = $"{uriPath}/";
            response.Node = currentNode;

            return View(response);
        }
    }
}