using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class ImagesDomain : IImagesDomain
{
    private readonly IImagesData _imagesData;
    
    public ImagesDomain(IImagesData imagesData)
    {
        _imagesData = imagesData;
    }
    
    public async Task<Images> GetById(int id)
    {
        var result = await _imagesData.GetById(id);
        if (result == null)
            throw new KeyNotFoundException("Response not found");

        return result;
    }

    public async Task<List<Images>> GetAll()
    {
        return await _imagesData.GetAll();
    }

    public async Task<ApiResponse<Images>> AddImage(Images image)
    {
        try
        {
            //var result = await _imagesData.GetById(images.Id);
            var createdImage = await _imagesData.Create(image);
            return ApiResponse<Images>.Success(createdImage);
        }
        catch (Exception e)
        {
            return ApiResponse<Images>.Error(e.Message);
        }
    }


    public async Task<bool> Update(Images images, int id)
    {
        try
        {
            var result = await _imagesData.GetById(id);

            if (result != null)
            {
                return await _imagesData.Update(images, id);
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var result = await _imagesData.GetById(id);

            if (result != null)
            {
                return await _imagesData.Delete(id);
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}