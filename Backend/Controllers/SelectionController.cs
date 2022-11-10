﻿using Backend.Dtos;
using Backend.Extensions;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.SelectionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("Selection")]
    [ApiController]
    public class SelectionController : ControllerBase
    {
        private readonly ISelectionService _selectionService;
        public SelectionController(ISelectionService selectionService)
        {
            _selectionService = selectionService;

        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSelectionsDto>>> GetAllSelections([FromQuery] UserParams userParams)
        {
            var selections = await _selectionService.GetAllSelections(userParams);
            Response.AddPaginationHeader(selections.CurrentPage, selections.PageSize, selections.TotalCount, selections.TotalPages);
            return Ok(selections);
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<GetSelectionDto>> GetById(int id)
        {
            return Ok(await _selectionService.GetSelectionById(id));

        }
        [HttpPost("AddSelection")]
        public async Task<ActionResult<GetSelectionsDto>> AddSelection (AddSelectionDto selectionDto)
        {
            return Ok(await _selectionService.AddSelection(selectionDto));
        }
        [HttpPatch("EditSelection")]
        public async Task<ActionResult<GetSelectionsDto>> EditSelection(int id, AddSelectionDto selectionDto)
        {
            return Ok(await _selectionService.EditSelection(id, selectionDto));
        }
        [HttpPatch("AddAppsToSelection")]
        public async Task<ActionResult<GetSelectionDto>> AddApplicantsToSelection(int selectionId, int applicationId)
        {
            return Ok(await _selectionService.AddApplicantsToSelection(selectionId, applicationId));
        }
        [HttpPatch("RemoveAppsToSelection")]
        public async Task<ActionResult<GetSelectionDto>> RemoveApplicantsToSelection(int selectionId, int applicationId)
        {
            return Ok(await _selectionService.RemoveApplicantToSelection(selectionId, applicationId));
        }
        [HttpPut("PostComment")]
        public async Task<ActionResult<GetSelectionDto>> PostSelectionComment(int selectionId, string comment)
        {
            return Ok(await _selectionService.AddCommentToSelection(selectionId, comment));
        }

    }
}
