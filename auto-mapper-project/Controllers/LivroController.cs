using auto_mapper_project.Dto;
using auto_mapper_project.DTO;
using auto_mapper_project.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace auto_mapper_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        public List<LivroModel> livros = new List<LivroModel>
        {
            new LivroModel
            { Id = 1,
              Titulo = "Titulo 1",
              Autor = "Autor 1",
              ISBN ="SRM123456",
              DataCriacao = new DateTime(2024,06,26)

            },
            new LivroModel
            { Id = 2,
              Titulo = "Titulo 2",
              Autor = "Autor 2",
              ISBN ="SRM23456",
              DataCriacao = new DateTime(2024,05,23)

            },
            new LivroModel
            { Id = 3,
              Titulo = "Titulo 3",
              Autor = "Autor 3",
              ISBN ="SRM3456",
              DataCriacao = new DateTime(2024,04,24)

            },
            new LivroModel
            { Id = 4,
              Titulo = "Titulo 4",
              Autor = "Autor 4",
              ISBN ="SRM456",
              DataCriacao = new DateTime(2024,03,25)

            }
        };

        private readonly IMapper _mapper;
        public LivroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("BuscaLivrosSemAutoMapper")]
        public ActionResult<List<LivroModel>> BuscaLivrosSemAutoMapper()
        {
            return Ok(livros);
        }

        [HttpGet("BuscaLivrosComAutoMapper")]
        public ActionResult<List<LivroModel>> BuscaLivrosComAutoMapper()
        {
            var livosDto = _mapper.Map<List<LivroVisualizacaoDTO>>(livros);
            return Ok(livosDto);
        }

        [HttpPost("CriarLivros")]
        public ActionResult<List<LivroModel>> CriarLivros(CriarLivrosDTO livro)
        {
            var livroModel = _mapper.Map<LivroModel>(livro);
            livroModel.Id = livros.Last().Id + 1;
            livros.Add(livroModel);
            return Ok(livros);
        }

    }
}
