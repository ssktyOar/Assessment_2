using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.GPU
{
    public enum VkResult
    {
        VK_SUCCESS = 0,
        VK_NOT_READY = 1,
        VK_TIMEOUT = 2,
        VK_EVENT_SET = 3,
        VK_EVENT_RESET = 4,
        VK_INCOMPLETE = 5,
        VK_ERROR_OUT_OF_HOST_MEMORY = -1,
        VK_ERROR_OUT_OF_DEVICE_MEMORY = -2,
        VK_ERROR_INITIALIZATION_FAILED = -3,
        VK_ERROR_DEVICE_LOST = -4,
        VK_ERROR_MEMORY_MAP_FAILED = -5,
        VK_ERROR_LAYER_NOT_PRESENT = -6,
        VK_ERROR_EXTENSION_NOT_PRESENT = -7,
        VK_ERROR_FEATURE_NOT_PRESENT = -8,
        VK_ERROR_INCOMPATIBLE_DRIVER = -9,
        VK_ERROR_TOO_MANY_OBJECTS = -10,
        VK_ERROR_FORMAT_NOT_SUPPORTED = -11,
        VK_ERROR_FRAGMENTED_POOL = -12,
        VK_ERROR_UNKNOWN = -13,
        // Provided by VK_VERSION_1_1
        VK_ERROR_OUT_OF_POOL_MEMORY = -1000069000,
        // Provided by VK_VERSION_1_1
        VK_ERROR_INVALID_EXTERNAL_HANDLE = -1000072003,
        // Provided by VK_VERSION_1_2
        VK_ERROR_FRAGMENTATION = -1000161000,
        // Provided by VK_VERSION_1_2
        VK_ERROR_INVALID_OPAQUE_CAPTURE_ADDRESS = -1000257000,
        // Provided by VK_VERSION_1_3
        VK_PIPELINE_COMPILE_REQUIRED = 1000297000,
    }
}
